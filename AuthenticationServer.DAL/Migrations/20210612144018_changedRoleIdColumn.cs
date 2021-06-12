using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationServer.DAL.Migrations
{
   public partial class changedRoleIdColumn : Migration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.RenameColumn(
             name: "RoleId",
             table: "ApplicationRole",
             newName: "Id");
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.RenameColumn(
             name: "Id",
             table: "ApplicationRole",
             newName: "RoleId");
      }
   }
}
