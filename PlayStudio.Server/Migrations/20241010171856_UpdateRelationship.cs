using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayStudio.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ClubEvent",
                type: "TEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<Guid>(
                name: "ClubId",
                table: "ClubEvent",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ClubEvent_ClubId",
                table: "ClubEvent",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubEvent_GameClub_ClubId",
                table: "ClubEvent",
                column: "ClubId",
                principalTable: "GameClub",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubEvent_GameClub_ClubId",
                table: "ClubEvent");

            migrationBuilder.DropIndex(
                name: "IX_ClubEvent_ClubId",
                table: "ClubEvent");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "ClubEvent");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ClubEvent",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
