using Lion.CodeGenerator.EntityFrameworkCore;
using Lion.CodeGenerator.MultiTenancy;
using Hangfire;
using Hangfire.MySql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Savorboard.CAP.InMemoryMessageQueue;
using StackExchange.Redis;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.CodeGenerator.Extensions.Filters;
using Lion.CodeGenerator.Extensions.Hangfire;
using Lion.CodeGenerator.Jobs;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Modularity;
using Lion.AbpPro.Shared.Hosting.Microservices;
using Lion.AbpPro.Shared.Hosting.Microservices.Microsoft.AspNetCore.Builder;
using Lion.AbpPro.Shared.Hosting.Microservices.Swaggers;
using Lion.AbpPro.CAP;
using Lion.AbpPro.ConfigurationOptions;

namespace Lion.CodeGenerator
{
    [DependsOn(
        typeof(CodeGeneratorHttpApiModule),
        typeof(SharedHostingMicroserviceModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
        typeof(CodeGeneratorEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpAccountWebModule),
        typeof(AbpBackgroundJobsHangfireModule),
        typeof(CodeGeneratorApplicationModule),
        typeof(AbpProAbpCapModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpCachingStackExchangeRedisModule)
    )]
    public class CodeGeneratorHttpApiHostModule : AbpModule
    {
        public override void OnPostApplicationInitialization(
            ApplicationInitializationContext context)
        {
            context.CreateRecurringJob();
            base.OnPostApplicationInitialization(context);
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            ConfigureCache(context);
            ConfigureSwaggerServices(context, configuration);
            ConfigureOptions(context);
            ConfigureJwtAuthentication(context, configuration);
            ConfigureHangfireMysql(context);
            ConfigurationCap(context);
            ConfigurationStsHttpClient(context);
            ConfigurationMiniProfiler(context);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var configuration = context.GetConfiguration();
            app.UseAbpRequestLocalization();
            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseMiniProfiler();
            app.UseRouting();
            app.UseCors(CodeGeneratorHttpApiHostConsts.DefaultCorsPolicyName);
            app.UseAuthentication();

            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseAuthorization();
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/CodeGenerator/swagger.json", "CodeGenerator API");
                options.DocExpansion(DocExpansion.None);
                options.DefaultModelsExpandDepth(-1);
            });

            app.UseAuditing();
            app.UseAbpSerilogEnrichers();

            app.UseUnitOfWork();
            app.UseConfiguredEndpoints(endpoints => { endpoints.MapHealthChecks("/health"); });
            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                Authorization = new[] { new CustomHangfireAuthorizeFilter() },
                IgnoreAntiforgeryToken = true
            });

            if (configuration.GetValue<bool>("Consul:Enabled", false))
            {
                app.UseConsul();
            }
        }


        private void ConfigureHangfireMysql(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => { options.IsJobExecutionEnabled = true; });
            context.Services.AddHangfire(config =>
            {
                config.UseStorage(new MySqlStorage(
                    context.Services.GetConfiguration().GetConnectionString("Default"),
                    new MySqlStorageOptions()
                    {
                        //CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        //SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        //QueuePollInterval = TimeSpan.Zero,
                        //UseRecommendedIsolationLevel = true,
                        //DisableGlobalLocks = true
                        JobExpirationCheckInterval = TimeSpan.FromMinutes(30)
                    }));
                var delaysInSeconds = new int[] { 10, 60, 60 * 3 }; // 重试时间间隔
                var Attempts = 3; // 重试次数
                config.UseFilter(new AutomaticRetryAttribute() { Attempts = Attempts, DelaysInSeconds = delaysInSeconds });
                config.UseFilter(new AutoDeleteAfterSuccessAttributer(TimeSpan.FromDays(7)));
                config.UseFilter(new JobRetryLastFilter(Attempts));
            });
        }

        /// <summary>
        /// 配置MiniProfiler
        /// </summary>
        /// <param name="context"></param>
        private void ConfigurationMiniProfiler(ServiceConfigurationContext context)
        {
            context.Services.AddMiniProfiler(options => options.RouteBasePath = "/profiler")
                .AddEntityFramework();
        }

        /// <summary>
        /// 配置JWT
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        private void ConfigureJwtAuthentication(ServiceConfigurationContext context,
            IConfiguration configuration)
        {
            context.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters =
                        new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                        {
                            // 是否开启签名认证
                            ValidateIssuerSigningKey = true,
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            //ClockSkew = TimeSpan.Zero,
                            ValidIssuer = configuration["Jwt:Issuer"],
                            ValidAudience = configuration["Jwt:Audience"],
                            IssuerSigningKey =
                                new SymmetricSecurityKey(
                                    Encoding.ASCII.GetBytes(configuration["Jwt:SecurityKey"]))
                        };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = currentContext =>
                        {
                            var path = currentContext.HttpContext.Request.Path;
                            if (path.StartsWithSegments("/login"))
                            {
                                return Task.CompletedTask;
                            }

                            var accessToken =
                                currentContext.Request.Query["access_token"].FirstOrDefault() ??
                                currentContext.Request.Cookies[
                                    CodeGeneratorHttpApiHostConsts.DefaultCookieName];

                            if (accessToken.IsNullOrWhiteSpace())
                            {
                                return Task.CompletedTask;
                            }

                            if (path.StartsWithSegments("/signalr"))
                            {
                                currentContext.Token = accessToken;
                            }

                            currentContext.Request.Headers.Remove("Authorization");
                            currentContext.Request.Headers.Add("Authorization",
                                $"Bearer {accessToken}");

                            // 如果请求来自hangfire 或者cap
                            if (path.ToString().StartsWith("/hangfire") ||
                                path.ToString().StartsWith("/cap"))
                            {
                                // currentContext.HttpContext.Response.Headers.Remove(
                                //     "X-Frame-Options");
                                currentContext.Token = accessToken;
                            }


                            return Task.CompletedTask;
                        }
                    };
                });
        }

        /// <summary>
        /// 配置options
        /// </summary>
        /// <param name="context"></param>
        private void ConfigureOptions(ServiceConfigurationContext context)
        {
            context.Services.Configure<JwtOptions>(context.Services.GetConfiguration()
                .GetSection("Jwt"));
        }

        /// <summary>
        /// Redis缓存
        /// </summary>
        private void ConfigureCache(ServiceConfigurationContext context)
        {
            Configure<AbpDistributedCacheOptions>(
                options => { options.KeyPrefix = "CodeGenerator:"; });
            var configuration = context.Services.GetConfiguration();
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            context.Services
                .AddDataProtection()
                .PersistKeysToStackExchangeRedis(redis, "CodeGenerator-Protection-Keys");
        }


        private void ConfigurationStsHttpClient(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClient(context.Services.GetConfiguration().GetSection("HttpClient:Sts:Name").Value,
                options =>
                {
                    options.BaseAddress =
                        new Uri(context.Services.GetConfiguration().GetSection("HttpClient:Sts:Url")
                            .Value);
                });
        }

        private void ConfigureConventionalControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(CodeGeneratorApplicationModule)
                    .Assembly);
            });
        }

        private static void ConfigureSwaggerServices(ServiceConfigurationContext context,
            IConfiguration configuration)
        {
            context.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("CodeGenerator",
                        new OpenApiInfo { Title = "LionCodeGenerator API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.EnableAnnotations(); // 启用注解
                    options.DocumentFilter<HiddenAbpDefaultApiFilter>();
                    options.SchemaFilter<EnumSchemaFilter>();
                    // 加载所有xml注释，这里会导致swagger加载有点缓慢
                    var xmls = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
                    foreach (var xml in xmls)
                    {
                        options.IncludeXmlComments(xml, true);
                    }

                    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme,
                        new OpenApiSecurityScheme()
                        {
                            Description = "直接在下框输入JWT生成的Token",
                            Name = "Authorization",
                            In = ParameterLocation.Header,
                            Type = SecuritySchemeType.Http,
                            Scheme = JwtBearerDefaults.AuthenticationScheme,
                            BearerFormat = "JWT"
                        });
                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme, Id = "Bearer"
                                }
                            },
                            new List<string>()
                        }
                    });

                    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme()
                    {
                        Type = SecuritySchemeType.ApiKey,
                        In = ParameterLocation.Header,
                        Name = "Accept-Language",
                        Description = "多语言设置，系统预设语言有zh-Hans、en，默认为zh-Hans"
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                    { Type = ReferenceType.SecurityScheme, Id = "ApiKey" }
                            },
                            new string[] { }
                        }
                    });
                });
        }


        private void ConfigurationCap(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var enabled = configuration.GetValue<bool>("Cap:Enabled", false);
            if (enabled)
            {
                context.AddAbpCap(capOptions =>
                {
                    capOptions.UseEntityFramework<CodeGeneratorDbContext>();
                    capOptions.UseRabbitMQ(option =>
                    {
                        option.HostName = configuration.GetValue<string>("Cap:RabbitMq:HostName");
                        option.UserName = configuration.GetValue<string>("Cap:RabbitMq:UserName");
                        option.Password = configuration.GetValue<string>("Cap:RabbitMq:Password");
                    });

                    var hostingEnvironment = context.Services.GetHostingEnvironment();
                    bool auth = !hostingEnvironment.IsDevelopment();
                    capOptions.UseDashboard(options => { options.UseAuth = auth; });
                });
            }
            else
            {
                context.AddAbpCap(capOptions =>
                {
                    capOptions.UseInMemoryStorage();
                    capOptions.UseInMemoryMessageQueue();
                    var hostingEnvironment = context.Services.GetHostingEnvironment();
                    bool auth = !hostingEnvironment.IsDevelopment();
                    capOptions.UseDashboard(options => { options.UseAuth = auth; });
                });
            }
        }
    }
}