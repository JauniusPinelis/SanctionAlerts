using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SanctionAlerts.Database.Migrations
{
    public partial class AddedLastDownloaded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastDownloaded",
                table: "FileInfos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastDownloaded",
                table: "FileInfos");
        }
    }
}
