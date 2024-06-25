using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatetransferEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransferDate",
                table: "Transfers",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ToAccountId",
                table: "Transfers",
                newName: "SenderUserId");

            migrationBuilder.RenameColumn(
                name: "FromAccountId",
                table: "Transfers",
                newName: "RecipientUserId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Transfers");

            migrationBuilder.RenameColumn(
                name: "SenderUserId",
                table: "Transfers",
                newName: "ToAccountId");

            migrationBuilder.RenameColumn(
                name: "RecipientUserId",
                table: "Transfers",
                newName: "FromAccountId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transfers",
                newName: "TransferDate");
        }
    }
}
