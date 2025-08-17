using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.Discord.Core.Migrations
{
    /// <inheritdoc />
    public partial class reportedmessageentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Channels_ChannelId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "ReportedMessages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ReportedMessages",
                newName: "ReporterId");

            migrationBuilder.RenameColumn(
                name: "MessageContent",
                table: "ReportedMessages",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "ReportedMessages",
                newName: "ReportedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChannelId",
                table: "ReportedMessages",
                newName: "IX_ReportedMessages_ChannelId");

            migrationBuilder.AlterColumn<int>(
                name: "ChannelId",
                table: "ReportedMessages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OffenderId",
                table: "ReportedMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportedMessages",
                table: "ReportedMessages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportedMessages_Channels_ChannelId",
                table: "ReportedMessages",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportedMessages_Channels_ChannelId",
                table: "ReportedMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportedMessages",
                table: "ReportedMessages");

            migrationBuilder.DropColumn(
                name: "OffenderId",
                table: "ReportedMessages");

            migrationBuilder.RenameTable(
                name: "ReportedMessages",
                newName: "Messages");

            migrationBuilder.RenameColumn(
                name: "ReporterId",
                table: "Messages",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ReportedAt",
                table: "Messages",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Messages",
                newName: "MessageContent");

            migrationBuilder.RenameIndex(
                name: "IX_ReportedMessages_ChannelId",
                table: "Messages",
                newName: "IX_Messages_ChannelId");

            migrationBuilder.AlterColumn<int>(
                name: "ChannelId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Channels_ChannelId",
                table: "Messages",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
