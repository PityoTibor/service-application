using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace service_data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Costumer",
                columns: table => new
                {
                    Costumer_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Costumer_user_idUser_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumer", x => x.Costumer_id);
                    table.ForeignKey(
                        name: "FK_Costumer_User_Costumer_user_idUser_id",
                        column: x => x.Costumer_user_idUser_id,
                        principalTable: "User",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Handyman",
                columns: table => new
                {
                    Handyman_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Handyman_user_idUser_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Handyman", x => x.Handyman_id);
                    table.ForeignKey(
                        name: "FK_Handyman_User_Handyman_user_idUser_id",
                        column: x => x.Handyman_user_idUser_id,
                        principalTable: "User",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Ticket_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Severity = table.Column<int>(type: "int", nullable: true),
                    statusEnum = table.Column<int>(type: "int", nullable: true),
                    HandymenHandyman_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Costumer_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Ticket_id);
                    table.ForeignKey(
                        name: "FK_Ticket_Costumer_Costumer_id",
                        column: x => x.Costumer_id,
                        principalTable: "Costumer",
                        principalColumn: "Costumer_id");
                    table.ForeignKey(
                        name: "FK_Ticket_Handyman_HandymenHandyman_id",
                        column: x => x.HandymenHandyman_id,
                        principalTable: "Handyman",
                        principalColumn: "Handyman_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Message_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Handyman_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Costumer_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Ticket_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Message_id);
                    table.ForeignKey(
                        name: "FK_Message_Costumer_Costumer_id",
                        column: x => x.Costumer_id,
                        principalTable: "Costumer",
                        principalColumn: "Costumer_id");
                    table.ForeignKey(
                        name: "FK_Message_Handyman_Handyman_id",
                        column: x => x.Handyman_id,
                        principalTable: "Handyman",
                        principalColumn: "Handyman_id");
                    table.ForeignKey(
                        name: "FK_Message_Ticket_Ticket_id",
                        column: x => x.Ticket_id,
                        principalTable: "Ticket",
                        principalColumn: "Ticket_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Costumer_Costumer_user_idUser_id",
                table: "Costumer",
                column: "Costumer_user_idUser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Handyman_Handyman_user_idUser_id",
                table: "Handyman",
                column: "Handyman_user_idUser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Costumer_id",
                table: "Message",
                column: "Costumer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Handyman_id",
                table: "Message",
                column: "Handyman_id");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Ticket_id",
                table: "Message",
                column: "Ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Costumer_id",
                table: "Ticket",
                column: "Costumer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_HandymenHandyman_id",
                table: "Ticket",
                column: "HandymenHandyman_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Costumer");

            migrationBuilder.DropTable(
                name: "Handyman");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
