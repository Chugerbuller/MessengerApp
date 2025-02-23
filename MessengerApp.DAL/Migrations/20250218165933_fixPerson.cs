using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessengerApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInChats_Users_UserId",
                table: "UsersInChats");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UsersInChats",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInChats_UserId",
                table: "UsersInChats",
                newName: "IX_UsersInChats_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInChats_Persons_PersonId",
                table: "UsersInChats",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInChats_Persons_PersonId",
                table: "UsersInChats");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "UsersInChats",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInChats_PersonId",
                table: "UsersInChats",
                newName: "IX_UsersInChats_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInChats_Users_UserId",
                table: "UsersInChats",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
