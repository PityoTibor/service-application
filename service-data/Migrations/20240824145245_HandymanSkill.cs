using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace service_data.Migrations
{
    /// <inheritdoc />
    public partial class HandymanSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Skill_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Skill_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HandymanSkill",
                columns: table => new
                {
                    Handyman_skill_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Handyman_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Skill_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandymanSkill", x => x.Handyman_skill_id);
                    table.ForeignKey(
                        name: "FK_HandymanSkill_Handyman_Handyman_id",
                        column: x => x.Handyman_id,
                        principalTable: "Handyman",
                        principalColumn: "Handyman_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HandymanSkill_Skill_Skill_id",
                        column: x => x.Skill_id,
                        principalTable: "Skill",
                        principalColumn: "Skill_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_HandymanSkill_Handyman_id",
                table: "HandymanSkill",
                column: "Handyman_id");

            migrationBuilder.CreateIndex(
                name: "IX_HandymanSkill_Skill_id",
                table: "HandymanSkill",
                column: "Skill_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HandymanSkill");

            migrationBuilder.DropTable(
                name: "Skill");
        }
    }
}
