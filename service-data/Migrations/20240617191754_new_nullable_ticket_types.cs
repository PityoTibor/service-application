using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace service_data.Migrations
{
    /// <inheritdoc />
    public partial class new_nullable_ticket_types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Costumer_Costumer_id",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Handyman_Handyman_id",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Ticket_Ticket_id",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Costumer_Costumer_id",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Handyman_Handyman_id",
                table: "Ticket");

            migrationBuilder.AlterColumn<Guid>(
                name: "Handyman_id",
                table: "Ticket",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Costumer_id",
                table: "Ticket",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Ticket_id",
                table: "Message",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Handyman_id",
                table: "Message",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Costumer_id",
                table: "Message",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Costumer_Costumer_id",
                table: "Message",
                column: "Costumer_id",
                principalTable: "Costumer",
                principalColumn: "Costumer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Handyman_Handyman_id",
                table: "Message",
                column: "Handyman_id",
                principalTable: "Handyman",
                principalColumn: "Handyman_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Ticket_Ticket_id",
                table: "Message",
                column: "Ticket_id",
                principalTable: "Ticket",
                principalColumn: "Ticket_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Costumer_Costumer_id",
                table: "Ticket",
                column: "Costumer_id",
                principalTable: "Costumer",
                principalColumn: "Costumer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Handyman_Handyman_id",
                table: "Ticket",
                column: "Handyman_id",
                principalTable: "Handyman",
                principalColumn: "Handyman_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Costumer_Costumer_id",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Handyman_Handyman_id",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Ticket_Ticket_id",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Costumer_Costumer_id",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Handyman_Handyman_id",
                table: "Ticket");

            migrationBuilder.AlterColumn<Guid>(
                name: "Handyman_id",
                table: "Ticket",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Costumer_id",
                table: "Ticket",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Ticket_id",
                table: "Message",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Handyman_id",
                table: "Message",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Costumer_id",
                table: "Message",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Costumer_Costumer_id",
                table: "Message",
                column: "Costumer_id",
                principalTable: "Costumer",
                principalColumn: "Costumer_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Handyman_Handyman_id",
                table: "Message",
                column: "Handyman_id",
                principalTable: "Handyman",
                principalColumn: "Handyman_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Ticket_Ticket_id",
                table: "Message",
                column: "Ticket_id",
                principalTable: "Ticket",
                principalColumn: "Ticket_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Costumer_Costumer_id",
                table: "Ticket",
                column: "Costumer_id",
                principalTable: "Costumer",
                principalColumn: "Costumer_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Handyman_Handyman_id",
                table: "Ticket",
                column: "Handyman_id",
                principalTable: "Handyman",
                principalColumn: "Handyman_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
