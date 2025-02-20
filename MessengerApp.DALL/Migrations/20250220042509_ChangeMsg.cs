using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessengerApp.DALL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMsg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInChats_Chats_ChatId",
                table: "UsersInChats");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInChats_Persons_PersonId",
                table: "UsersInChats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInChats",
                table: "UsersInChats");

            migrationBuilder.RenameTable(
                name: "UsersInChats",
                newName: "PersonsInChat");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInChats_PersonId",
                table: "PersonsInChat",
                newName: "IX_PersonsInChat_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInChats_ChatId",
                table: "PersonsInChat",
                newName: "IX_PersonsInChat_ChatId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Message",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Message",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonsInChat",
                table: "PersonsInChat",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Message_PersonId",
                table: "Message",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Persons_PersonId",
                table: "Message",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonsInChat_Chats_ChatId",
                table: "PersonsInChat",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonsInChat_Persons_PersonId",
                table: "PersonsInChat",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Persons_PersonId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonsInChat_Chats_ChatId",
                table: "PersonsInChat");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonsInChat_Persons_PersonId",
                table: "PersonsInChat");

            migrationBuilder.DropIndex(
                name: "IX_Message_PersonId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonsInChat",
                table: "PersonsInChat");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "PersonsInChat",
                newName: "UsersInChats");

            migrationBuilder.RenameIndex(
                name: "IX_PersonsInChat_PersonId",
                table: "UsersInChats",
                newName: "IX_UsersInChats_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonsInChat_ChatId",
                table: "UsersInChats",
                newName: "IX_UsersInChats_ChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInChats",
                table: "UsersInChats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInChats_Chats_ChatId",
                table: "UsersInChats",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInChats_Persons_PersonId",
                table: "UsersInChats",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
