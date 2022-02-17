using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lion.CodeGenerator.Migrations
{
    public partial class AddAggregateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gen_AggregateModel",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BusinessLineId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BusinessProjectId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gen_AggregateModel", x => new { x.TenantId, x.BusinessLineId, x.BusinessProjectId, x.Code });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Gen_EntityModel",
                columns: table => new
                {
                    AggregateModelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RelationType = table.Column<int>(type: "int", nullable: false),
                    AggregateModelBusinessLineId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AggregateModelBusinessProjectId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AggregateModelCode = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AggregateModelTenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gen_EntityModel", x => new { x.AggregateModelId, x.Code });
                    table.ForeignKey(
                        name: "FK_Gen_EntityModel_Gen_AggregateModel_AggregateModelTenantId_Ag~",
                        columns: x => new { x.AggregateModelTenantId, x.AggregateModelBusinessLineId, x.AggregateModelBusinessProjectId, x.AggregateModelCode },
                        principalTable: "Gen_AggregateModel",
                        principalColumns: new[] { "TenantId", "BusinessLineId", "BusinessProjectId", "Code" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Gen_PropertyModel",
                columns: table => new
                {
                    AggregateModelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsRequired = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnumModelId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    StringMaxLength = table.Column<int>(type: "int", nullable: false),
                    DecimalPrecision = table.Column<int>(type: "int", nullable: false),
                    DecimalScale = table.Column<int>(type: "int", nullable: false),
                    AggregateModelBusinessLineId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AggregateModelBusinessProjectId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AggregateModelCode = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AggregateModelTenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EntityModelAggregateModelId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    EntityModelCode = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gen_PropertyModel", x => new { x.AggregateModelId, x.Code });
                    table.ForeignKey(
                        name: "FK_Gen_PropertyModel_Gen_AggregateModel_AggregateModelTenantId_~",
                        columns: x => new { x.AggregateModelTenantId, x.AggregateModelBusinessLineId, x.AggregateModelBusinessProjectId, x.AggregateModelCode },
                        principalTable: "Gen_AggregateModel",
                        principalColumns: new[] { "TenantId", "BusinessLineId", "BusinessProjectId", "Code" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gen_PropertyModel_Gen_EntityModel_EntityModelAggregateModelI~",
                        columns: x => new { x.EntityModelAggregateModelId, x.EntityModelCode },
                        principalTable: "Gen_EntityModel",
                        principalColumns: new[] { "AggregateModelId", "Code" });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Gen_EntityModel_AggregateModelTenantId_AggregateModelBusines~",
                table: "Gen_EntityModel",
                columns: new[] { "AggregateModelTenantId", "AggregateModelBusinessLineId", "AggregateModelBusinessProjectId", "AggregateModelCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Gen_PropertyModel_AggregateModelTenantId_AggregateModelBusin~",
                table: "Gen_PropertyModel",
                columns: new[] { "AggregateModelTenantId", "AggregateModelBusinessLineId", "AggregateModelBusinessProjectId", "AggregateModelCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Gen_PropertyModel_EntityModelAggregateModelId_EntityModelCode",
                table: "Gen_PropertyModel",
                columns: new[] { "EntityModelAggregateModelId", "EntityModelCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gen_PropertyModel");

            migrationBuilder.DropTable(
                name: "Gen_EntityModel");

            migrationBuilder.DropTable(
                name: "Gen_AggregateModel");
        }
    }
}
