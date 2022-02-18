﻿using Lion.AbpPro.Tenants;
using Lion.AbpPro.Tenants.Dtos;
using Lion.AbpPro.Users;
using Lion.CodeGenerator.Tool.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;
using System.Windows.Input;

namespace Lion.CodeGenerator.Tool.ViewModels
{
    public class LoginWinViewModel : BindableBase
    {
        public ICommand LoginCommand { get; set; }
        public UserModel UserModel { get; set; } = new UserModel();

        private readonly IVoloTenantAppService _tenantAppService;
        private readonly IAccountAppService _accountAppService;
        public LoginWinViewModel(
            //IVoloTenantAppService tenantAppService,
            //IAccountAppService accountAppService
            )
        {
            LoginCommand = new DelegateCommand<object>(OnLogin);
            //this._tenantAppService = tenantAppService;
            //this._accountAppService = accountAppService;
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private string _loadingMessage;

        public string LoadingMessage
        {
            get { return _loadingMessage; }
            set { SetProperty(ref _loadingMessage, value); }
        }

        private string _errorMessage;


        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        private async void OnLogin(object obj)
        {
            if (string.IsNullOrEmpty(UserModel.TenantName))
            {
                this.ErrorMessage = "请输入租户";
                return;
            }

            if (string.IsNullOrEmpty(UserModel.UserName))
            {
                this.ErrorMessage = "请输入用户名";
                return;
            }

            if (string.IsNullOrEmpty(UserModel.Password))
            {
                this.ErrorMessage = "请输入密码";
                return;
            }

            this.LoadingMessage = "正在登录....";
            this.IsLoading = true;

            try
            {
                var input = new FindTenantByNameInput();
                input.Name = UserModel.TenantName;
                var tenantResultDto = await _tenantAppService.FindTenantByNameAsync(input);
                if (tenantResultDto == null || tenantResultDto.Success == false)
                {
                    MessageBox.Show($"租户：{input.Name}不存在.");
                    return;
                }


            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
