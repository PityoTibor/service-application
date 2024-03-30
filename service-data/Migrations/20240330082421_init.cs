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
                name: "Message",
                columns: table => new
                {
                    Message_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SenderUser_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Ticket_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Message_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Ticket_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CostumerUser_Id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    HandymanUser_Id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Severity = table.Column<int>(type: "int", nullable: true),
                    statusEnum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Ticket_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<int>(type: "int", nullable: true),
                    Ticket_Id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_Id);
                    table.ForeignKey(
                        name: "FK_User_Ticket_Ticket_Id",
                        column: x => x.Ticket_Id,
                        principalTable: "Ticket",
                        principalColumn: "Ticket_Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderUser_Id",
                table: "Message",
                column: "SenderUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Ticket_Id",
                table: "Message",
                column: "Ticket_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CostumerUser_Id",
                table: "Ticket",
                column: "CostumerUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_HandymanUser_Id",
                table: "Ticket",
                column: "HandymanUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Ticket_Id",
                table: "User",
                column: "Ticket_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Ticket_Ticket_Id",
                table: "Message",
                column: "Ticket_Id",
                principalTable: "Ticket",
                principalColumn: "Ticket_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_SenderUser_Id",
                table: "Message",
                column: "SenderUser_Id",
                principalTable: "User",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_User_CostumerUser_Id",
                table: "Ticket",
                column: "CostumerUser_Id",
                principalTable: "User",
                principalColumn: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_User_HandymanUser_Id",
                table: "Ticket",
                column: "HandymanUser_Id",
                principalTable: "User",
                principalColumn: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Ticket_Ticket_Id",
                table: "User");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
