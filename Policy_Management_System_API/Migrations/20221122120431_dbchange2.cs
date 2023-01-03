using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Policy_Management_System_API.Migrations
{
    public partial class dbchange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_policy_housedetail_HouseDetailId",
                table: "policy");

            migrationBuilder.DropForeignKey(
                name: "FK_policy_vehicledetail_VehicleDetailId",
                table: "policy");

            migrationBuilder.DropIndex(
                name: "IX_policy_HouseDetailId",
                table: "policy");

            migrationBuilder.DropIndex(
                name: "IX_policy_VehicleDetailId",
                table: "policy");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleDetailId",
                table: "policy",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HouseDetailId",
                table: "policy",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_policy_HouseDetailId",
                table: "policy",
                column: "HouseDetailId",
                unique: true,
                filter: "[HouseDetailId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_policy_VehicleDetailId",
                table: "policy",
                column: "VehicleDetailId",
                unique: true,
                filter: "[VehicleDetailId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_policy_housedetail_HouseDetailId",
                table: "policy",
                column: "HouseDetailId",
                principalTable: "housedetail",
                principalColumn: "HouseDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_policy_vehicledetail_VehicleDetailId",
                table: "policy",
                column: "VehicleDetailId",
                principalTable: "vehicledetail",
                principalColumn: "VehicleDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_policy_housedetail_HouseDetailId",
                table: "policy");

            migrationBuilder.DropForeignKey(
                name: "FK_policy_vehicledetail_VehicleDetailId",
                table: "policy");

            migrationBuilder.DropIndex(
                name: "IX_policy_HouseDetailId",
                table: "policy");

            migrationBuilder.DropIndex(
                name: "IX_policy_VehicleDetailId",
                table: "policy");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleDetailId",
                table: "policy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HouseDetailId",
                table: "policy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_policy_HouseDetailId",
                table: "policy",
                column: "HouseDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_policy_VehicleDetailId",
                table: "policy",
                column: "VehicleDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_policy_housedetail_HouseDetailId",
                table: "policy",
                column: "HouseDetailId",
                principalTable: "housedetail",
                principalColumn: "HouseDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_policy_vehicledetail_VehicleDetailId",
                table: "policy",
                column: "VehicleDetailId",
                principalTable: "vehicledetail",
                principalColumn: "VehicleDetailId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
