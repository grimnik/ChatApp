using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LetsChat.Data.Migrations
{
    public partial class MadeChannelAndGroupClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroepId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groepen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true),
                    Public = table.Column<bool>(nullable: false),
                    Beschrijving = table.Column<string>(nullable: true),
                    Foto = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groepen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true),
                    GroepId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Channels_Groepen_GroepId",
                        column: x => x.GroepId,
                        principalTable: "Groepen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GroepId",
                table: "AspNetUsers",
                column: "GroepId");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_GroepId",
                table: "Channels",
                column: "GroepId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groepen_GroepId",
                table: "AspNetUsers",
                column: "GroepId",
                principalTable: "Groepen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groepen_GroepId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "Groepen");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GroepId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GroepId",
                table: "AspNetUsers");
        }
    }
}
