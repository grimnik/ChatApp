using Microsoft.EntityFrameworkCore.Migrations;

namespace LetsChat.Data.Migrations
{
    public partial class GroupIdInChannel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_Groepen_GroepId",
                table: "Channels");

            migrationBuilder.AlterColumn<int>(
                name: "GroepId",
                table: "Channels",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_Groepen_GroepId",
                table: "Channels",
                column: "GroepId",
                principalTable: "Groepen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_Groepen_GroepId",
                table: "Channels");

            migrationBuilder.AlterColumn<int>(
                name: "GroepId",
                table: "Channels",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_Groepen_GroepId",
                table: "Channels",
                column: "GroepId",
                principalTable: "Groepen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
