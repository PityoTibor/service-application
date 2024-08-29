using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace service_data.Migrations
{
    /// <inheritdoc />
    public partial class ticketSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketSkill",
                columns: table => new
                {
                    TicketSkill_skill_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Ticket_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Skill_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSkill", x => x.TicketSkill_skill_id);
                    table.ForeignKey(
                        name: "FK_TicketSkill_Skill_Skill_id",
                        column: x => x.Skill_id,
                        principalTable: "Skill",
                        principalColumn: "Skill_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketSkill_Ticket_Ticket_id",
                        column: x => x.Ticket_id,
                        principalTable: "Ticket",
                        principalColumn: "Ticket_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSkill_Skill_id",
                table: "TicketSkill",
                column: "Skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSkill_Ticket_id",
                table: "TicketSkill",
                column: "Ticket_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketSkill");
        }
    }
}
