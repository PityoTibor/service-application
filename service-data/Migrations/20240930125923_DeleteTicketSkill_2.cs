using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace service_data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTicketSkill_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ticketskill_tbl_skill_Skill_id",
                table: "tbl_ticketskill");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ticketskill_tbl_ticket_Ticket_id",
                table: "tbl_ticketskill");

            migrationBuilder.DropIndex(
                name: "IX_tbl_ticketskill_Skill_id",
                table: "tbl_ticketskill");

            migrationBuilder.DropIndex(
                name: "IX_tbl_ticketskill_Ticket_id",
                table: "tbl_ticketskill");

            migrationBuilder.AddColumn<Guid>(
                name: "Skill_id1",
                table: "tbl_ticketskill",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Ticket_id1",
                table: "tbl_ticketskill",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ticketskill_Skill_id1",
                table: "tbl_ticketskill",
                column: "Skill_id1");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ticketskill_Ticket_id1",
                table: "tbl_ticketskill",
                column: "Ticket_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ticketskill_tbl_skill_Skill_id1",
                table: "tbl_ticketskill",
                column: "Skill_id1",
                principalTable: "tbl_skill",
                principalColumn: "Skill_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ticketskill_tbl_ticket_Ticket_id1",
                table: "tbl_ticketskill",
                column: "Ticket_id1",
                principalTable: "tbl_ticket",
                principalColumn: "Ticket_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ticketskill_tbl_skill_Skill_id1",
                table: "tbl_ticketskill");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ticketskill_tbl_ticket_Ticket_id1",
                table: "tbl_ticketskill");

            migrationBuilder.DropIndex(
                name: "IX_tbl_ticketskill_Skill_id1",
                table: "tbl_ticketskill");

            migrationBuilder.DropIndex(
                name: "IX_tbl_ticketskill_Ticket_id1",
                table: "tbl_ticketskill");

            migrationBuilder.DropColumn(
                name: "Skill_id1",
                table: "tbl_ticketskill");

            migrationBuilder.DropColumn(
                name: "Ticket_id1",
                table: "tbl_ticketskill");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ticketskill_Skill_id",
                table: "tbl_ticketskill",
                column: "Skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ticketskill_Ticket_id",
                table: "tbl_ticketskill",
                column: "Ticket_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ticketskill_tbl_skill_Skill_id",
                table: "tbl_ticketskill",
                column: "Skill_id",
                principalTable: "tbl_skill",
                principalColumn: "Skill_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ticketskill_tbl_ticket_Ticket_id",
                table: "tbl_ticketskill",
                column: "Ticket_id",
                principalTable: "tbl_ticket",
                principalColumn: "Ticket_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
