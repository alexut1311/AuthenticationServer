using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AuthenticationServer.DAL.Migrations
{
   public partial class AddedUserRefreshTokenExpirationDate : Migration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.AddColumn<DateTime>(
             name: "ExpirationDate",
             table: "RefreshTokens",
             type: "datetime2",
             nullable: false,
             defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropColumn(
             name: "ExpirationDate",
             table: "RefreshTokens");
      }
   }
}
