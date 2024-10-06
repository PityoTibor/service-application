using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace service_data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTicketSkill_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_ticketskill");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_ticketskill",
                columns: table => new
                {
                    TicketSkill_skill_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Skill_id1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Ticket_id1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Skill_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Ticket_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ticketskill", x => x.TicketSkill_skill_id);
                    table.ForeignKey(
                        name: "FK_tbl_ticketskill_tbl_skill_Skill_id1",
                        column: x => x.Skill_id1,
                        principalTable: "tbl_skill",
                        principalColumn: "Skill_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_ticketskill_tbl_ticket_Ticket_id1",
                        column: x => x.Ticket_id1,
                        principalTable: "tbl_ticket",
                        principalColumn: "Ticket_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ticketskill_Skill_id1",
                table: "tbl_ticketskill",
                column: "Skill_id1");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ticketskill_Ticket_id1",
                table: "tbl_ticketskill",
                column: "Ticket_id1");
        }
    }
}
