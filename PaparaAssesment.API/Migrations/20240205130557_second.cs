using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaparaAssesment.API.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Residents_ResidentsResidentId",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "FlatId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "Payments",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "PaymentCategory",
                table: "Payments",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "isAvailable",
                table: "Flats",
                newName: "IsAvailable");

            migrationBuilder.RenameColumn(
                name: "ResidentsResidentId",
                table: "Flats",
                newName: "PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Flats_ResidentsResidentId",
                table: "Flats",
                newName: "IX_Flats_PaymentId");

            migrationBuilder.AddColumn<int>(
                name: "FlatId",
                table: "Residents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ResidentId",
                table: "Payments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_FlatId",
                table: "Residents",
                column: "FlatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ResidentId",
                table: "Payments",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Payments_PaymentId",
                table: "Flats",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Residents_ResidentId",
                table: "Payments",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Flats_FlatId",
                table: "Residents",
                column: "FlatId",
                principalTable: "Flats",
                principalColumn: "FlatId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Payments_PaymentId",
                table: "Flats");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Residents_ResidentId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Flats_FlatId",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Residents_FlatId",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ResidentId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "FlatId",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Payments",
                newName: "PaymentCategory");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Payments",
                newName: "PaymentDate");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "Flats",
                newName: "isAvailable");

            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "Flats",
                newName: "ResidentsResidentId");

            migrationBuilder.RenameIndex(
                name: "IX_Flats_PaymentId",
                table: "Flats",
                newName: "IX_Flats_ResidentsResidentId");

            migrationBuilder.AlterColumn<int>(
                name: "ResidentId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlatId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentType",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_Residents_ResidentsResidentId",
                table: "Flats",
                column: "ResidentsResidentId",
                principalTable: "Residents",
                principalColumn: "ResidentId");
        }
    }
}
