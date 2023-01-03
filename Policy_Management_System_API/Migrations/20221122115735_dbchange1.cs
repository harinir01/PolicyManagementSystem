using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Policy_Management_System_API.Migrations
{
    public partial class dbchange1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coverage",
                columns: table => new
                {
                    CoverageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coverage", x => x.CoverageId);
                });

            migrationBuilder.CreateTable(
                name: "housedetail",
                columns: table => new
                {
                    HouseDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetValue = table.Column<float>(type: "real", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_housedetail", x => x.HouseDetailId);
                });

            migrationBuilder.CreateTable(
                name: "policytype",
                columns: table => new
                {
                    PolicyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Policytype = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_policytype", x => x.PolicyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "vehicledetail",
                columns: table => new
                {
                    VehicleDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicledetail", x => x.VehicleDetailId);
                });

            migrationBuilder.CreateTable(
                name: "policy",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Premium = table.Column<float>(type: "real", nullable: true),
                    Duration = table.Column<float>(type: "real", nullable: true),
                    InsuredAmount = table.Column<float>(type: "real", nullable: false),
                    InsuredName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    InsuredHolderAge = table.Column<int>(type: "int", nullable: false),
                    PolicyTypeId = table.Column<int>(type: "int", nullable: false),
                    CoverageId = table.Column<int>(type: "int", nullable: false),
                    HouseDetailId = table.Column<int>(type: "int", nullable: false),
                    VehicleDetailId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_policy", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK_policy_coverage_CoverageId",
                        column: x => x.CoverageId,
                        principalTable: "coverage",
                        principalColumn: "CoverageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_policy_housedetail_HouseDetailId",
                        column: x => x.HouseDetailId,
                        principalTable: "housedetail",
                        principalColumn: "HouseDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_policy_policytype_PolicyTypeId",
                        column: x => x.PolicyTypeId,
                        principalTable: "policytype",
                        principalColumn: "PolicyTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_policy_vehicledetail_VehicleDetailId",
                        column: x => x.VehicleDetailId,
                        principalTable: "vehicledetail",
                        principalColumn: "VehicleDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_policy_CoverageId",
                table: "policy",
                column: "CoverageId");

            migrationBuilder.CreateIndex(
                name: "IX_policy_HouseDetailId",
                table: "policy",
                column: "HouseDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_policy_PolicyTypeId",
                table: "policy",
                column: "PolicyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_policy_VehicleDetailId",
                table: "policy",
                column: "VehicleDetailId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "policy");

            migrationBuilder.DropTable(
                name: "coverage");

            migrationBuilder.DropTable(
                name: "housedetail");

            migrationBuilder.DropTable(
                name: "policytype");

            migrationBuilder.DropTable(
                name: "vehicledetail");
        }
    }
}
