using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace service_data.Migrations
{
    /// <inheritdoc />
    public partial class newColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_User_User_id",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Costumer_User_User_id",
                table: "Costumer");

            migrationBuilder.DropForeignKey(
                name: "FK_Handyman_User_User_id",
                table: "Handyman");

            migrationBuilder.DropForeignKey(
                name: "FK_HandymanSkill_Handyman_Handyman_id",
                table: "HandymanSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_HandymanSkill_Skill_Skill_id",
                table: "HandymanSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_Interval_Handyman_Handyman_id",
                table: "Interval");

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

            migrationBuilder.DropForeignKey(
                name: "FK_TicketSkill_Skill_Skill_id",
                table: "TicketSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketSkill_Ticket_Ticket_id",
                table: "TicketSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketSkill",
                table: "TicketSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interval",
                table: "Interval");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HandymanSkill",
                table: "HandymanSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Handyman",
                table: "Handyman");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Costumer",
                table: "Costumer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "tbl_user");

            migrationBuilder.RenameTable(
                name: "TicketSkill",
                newName: "tbl_ticketskill");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "tbl_ticket");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "tbl_skill");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "tbl_message");

            migrationBuilder.RenameTable(
                name: "Interval",
                newName: "tbl_interval");

            migrationBuilder.RenameTable(
                name: "HandymanSkill",
                newName: "tbl_handymanskill");

            migrationBuilder.RenameTable(
                name: "Handyman",
                newName: "tbl_handyman");

            migrationBuilder.RenameTable(
                name: "Costumer",
                newName: "tbl_costumer");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "tbl_admin");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSkill_Ticket_id",
                table: "tbl_ticketskill",
                newName: "IX_tbl_ticketskill_Ticket_id");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSkill_Skill_id",
                table: "tbl_ticketskill",
                newName: "IX_tbl_ticketskill_Skill_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Handyman_id",
                table: "tbl_ticket",
                newName: "IX_tbl_ticket_Handyman_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Costumer_id",
                table: "tbl_ticket",
                newName: "IX_tbl_ticket_Costumer_id");

            migrationBuilder.RenameIndex(
                name: "IX_Message_Ticket_id",
                table: "tbl_message",
                newName: "IX_tbl_message_Ticket_id");

            migrationBuilder.RenameIndex(
                name: "IX_Message_Handyman_id",
                table: "tbl_message",
                newName: "IX_tbl_message_Handyman_id");

            migrationBuilder.RenameIndex(
                name: "IX_Message_Costumer_id",
                table: "tbl_message",
                newName: "IX_tbl_message_Costumer_id");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "tbl_interval",
                newName: "ToDate");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "tbl_interval",
                newName: "FromDate");

            migrationBuilder.RenameIndex(
                name: "IX_Interval_Handyman_id",
                table: "tbl_interval",
                newName: "IX_tbl_interval_Handyman_id");

            migrationBuilder.RenameIndex(
                name: "IX_HandymanSkill_Skill_id",
                table: "tbl_handymanskill",
                newName: "IX_tbl_handymanskill_Skill_id");

            migrationBuilder.RenameIndex(
                name: "IX_HandymanSkill_Handyman_id",
                table: "tbl_handymanskill",
                newName: "IX_tbl_handymanskill_Handyman_id");

            migrationBuilder.RenameIndex(
                name: "IX_Handyman_User_id",
                table: "tbl_handyman",
                newName: "IX_tbl_handyman_User_id");

            migrationBuilder.RenameIndex(
                name: "IX_Costumer_User_id",
                table: "tbl_costumer",
                newName: "IX_tbl_costumer_User_id");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_User_id",
                table: "tbl_admin",
                newName: "IX_tbl_admin_User_id");

            migrationBuilder.AddColumn<bool>(
                name: "IsAutoAssing",
                table: "tbl_skill",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_user",
                table: "tbl_user",
                column: "User_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_ticketskill",
                table: "tbl_ticketskill",
                column: "TicketSkill_skill_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_ticket",
                table: "tbl_ticket",
                column: "Ticket_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_skill",
                table: "tbl_skill",
                column: "Skill_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_message",
                table: "tbl_message",
                column: "Message_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_interval",
                table: "tbl_interval",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_handymanskill",
                table: "tbl_handymanskill",
                column: "Handyman_skill_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_handyman",
                table: "tbl_handyman",
                column: "Handyman_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_costumer",
                table: "tbl_costumer",
                column: "Costumer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_admin",
                table: "tbl_admin",
                column: "Admin_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_admin_tbl_user_User_id",
                table: "tbl_admin",
                column: "User_id",
                principalTable: "tbl_user",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_costumer_tbl_user_User_id",
                table: "tbl_costumer",
                column: "User_id",
                principalTable: "tbl_user",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_handyman_tbl_user_User_id",
                table: "tbl_handyman",
                column: "User_id",
                principalTable: "tbl_user",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_handymanskill_tbl_handyman_Handyman_id",
                table: "tbl_handymanskill",
                column: "Handyman_id",
                principalTable: "tbl_handyman",
                principalColumn: "Handyman_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_handymanskill_tbl_skill_Skill_id",
                table: "tbl_handymanskill",
                column: "Skill_id",
                principalTable: "tbl_skill",
                principalColumn: "Skill_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_interval_tbl_handyman_Handyman_id",
                table: "tbl_interval",
                column: "Handyman_id",
                principalTable: "tbl_handyman",
                principalColumn: "Handyman_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_message_tbl_costumer_Costumer_id",
                table: "tbl_message",
                column: "Costumer_id",
                principalTable: "tbl_costumer",
                principalColumn: "Costumer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_message_tbl_handyman_Handyman_id",
                table: "tbl_message",
                column: "Handyman_id",
                principalTable: "tbl_handyman",
                principalColumn: "Handyman_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_message_tbl_ticket_Ticket_id",
                table: "tbl_message",
                column: "Ticket_id",
                principalTable: "tbl_ticket",
                principalColumn: "Ticket_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ticket_tbl_costumer_Costumer_id",
                table: "tbl_ticket",
                column: "Costumer_id",
                principalTable: "tbl_costumer",
                principalColumn: "Costumer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ticket_tbl_handyman_Handyman_id",
                table: "tbl_ticket",
                column: "Handyman_id",
                principalTable: "tbl_handyman",
                principalColumn: "Handyman_id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_admin_tbl_user_User_id",
                table: "tbl_admin");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_costumer_tbl_user_User_id",
                table: "tbl_costumer");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_handyman_tbl_user_User_id",
                table: "tbl_handyman");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_handymanskill_tbl_handyman_Handyman_id",
                table: "tbl_handymanskill");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_handymanskill_tbl_skill_Skill_id",
                table: "tbl_handymanskill");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_interval_tbl_handyman_Handyman_id",
                table: "tbl_interval");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_message_tbl_costumer_Costumer_id",
                table: "tbl_message");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_message_tbl_handyman_Handyman_id",
                table: "tbl_message");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_message_tbl_ticket_Ticket_id",
                table: "tbl_message");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ticket_tbl_costumer_Costumer_id",
                table: "tbl_ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ticket_tbl_handyman_Handyman_id",
                table: "tbl_ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ticketskill_tbl_skill_Skill_id",
                table: "tbl_ticketskill");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ticketskill_tbl_ticket_Ticket_id",
                table: "tbl_ticketskill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_user",
                table: "tbl_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_ticketskill",
                table: "tbl_ticketskill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_ticket",
                table: "tbl_ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_skill",
                table: "tbl_skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_message",
                table: "tbl_message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_interval",
                table: "tbl_interval");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_handymanskill",
                table: "tbl_handymanskill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_handyman",
                table: "tbl_handyman");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_costumer",
                table: "tbl_costumer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_admin",
                table: "tbl_admin");

            migrationBuilder.DropColumn(
                name: "IsAutoAssing",
                table: "tbl_skill");

            migrationBuilder.RenameTable(
                name: "tbl_user",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "tbl_ticketskill",
                newName: "TicketSkill");

            migrationBuilder.RenameTable(
                name: "tbl_ticket",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "tbl_skill",
                newName: "Skill");

            migrationBuilder.RenameTable(
                name: "tbl_message",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "tbl_interval",
                newName: "Interval");

            migrationBuilder.RenameTable(
                name: "tbl_handymanskill",
                newName: "HandymanSkill");

            migrationBuilder.RenameTable(
                name: "tbl_handyman",
                newName: "Handyman");

            migrationBuilder.RenameTable(
                name: "tbl_costumer",
                newName: "Costumer");

            migrationBuilder.RenameTable(
                name: "tbl_admin",
                newName: "Admin");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_ticketskill_Ticket_id",
                table: "TicketSkill",
                newName: "IX_TicketSkill_Ticket_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_ticketskill_Skill_id",
                table: "TicketSkill",
                newName: "IX_TicketSkill_Skill_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_ticket_Handyman_id",
                table: "Ticket",
                newName: "IX_Ticket_Handyman_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_ticket_Costumer_id",
                table: "Ticket",
                newName: "IX_Ticket_Costumer_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_message_Ticket_id",
                table: "Message",
                newName: "IX_Message_Ticket_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_message_Handyman_id",
                table: "Message",
                newName: "IX_Message_Handyman_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_message_Costumer_id",
                table: "Message",
                newName: "IX_Message_Costumer_id");

            migrationBuilder.RenameColumn(
                name: "ToDate",
                table: "Interval",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "FromDate",
                table: "Interval",
                newName: "From");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_interval_Handyman_id",
                table: "Interval",
                newName: "IX_Interval_Handyman_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_handymanskill_Skill_id",
                table: "HandymanSkill",
                newName: "IX_HandymanSkill_Skill_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_handymanskill_Handyman_id",
                table: "HandymanSkill",
                newName: "IX_HandymanSkill_Handyman_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_handyman_User_id",
                table: "Handyman",
                newName: "IX_Handyman_User_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_costumer_User_id",
                table: "Costumer",
                newName: "IX_Costumer_User_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_admin_User_id",
                table: "Admin",
                newName: "IX_Admin_User_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "User_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketSkill",
                table: "TicketSkill",
                column: "TicketSkill_skill_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Ticket_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Skill_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Message_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interval",
                table: "Interval",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HandymanSkill",
                table: "HandymanSkill",
                column: "Handyman_skill_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Handyman",
                table: "Handyman",
                column: "Handyman_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Costumer",
                table: "Costumer",
                column: "Costumer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "Admin_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_User_User_id",
                table: "Admin",
                column: "User_id",
                principalTable: "User",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Costumer_User_User_id",
                table: "Costumer",
                column: "User_id",
                principalTable: "User",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Handyman_User_User_id",
                table: "Handyman",
                column: "User_id",
                principalTable: "User",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HandymanSkill_Handyman_Handyman_id",
                table: "HandymanSkill",
                column: "Handyman_id",
                principalTable: "Handyman",
                principalColumn: "Handyman_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HandymanSkill_Skill_Skill_id",
                table: "HandymanSkill",
                column: "Skill_id",
                principalTable: "Skill",
                principalColumn: "Skill_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interval_Handyman_Handyman_id",
                table: "Interval",
                column: "Handyman_id",
                principalTable: "Handyman",
                principalColumn: "Handyman_id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_TicketSkill_Skill_Skill_id",
                table: "TicketSkill",
                column: "Skill_id",
                principalTable: "Skill",
                principalColumn: "Skill_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketSkill_Ticket_Ticket_id",
                table: "TicketSkill",
                column: "Ticket_id",
                principalTable: "Ticket",
                principalColumn: "Ticket_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
