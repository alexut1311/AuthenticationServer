using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationServer.DAL.Migrations
{
   public partial class init : Migration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropForeignKey(
             name: "FK_Users_ApplicationRole_RoleId",
             table: "Users");

         migrationBuilder.DropPrimaryKey(
             name: "PK_ApplicationRole",
             table: "ApplicationRole");

         migrationBuilder.RenameTable(
             name: "ApplicationRole",
             newName: "Roles");

         migrationBuilder.AddPrimaryKey(
             name: "PK_Roles",
             table: "Roles",
             column: "Id");

         migrationBuilder.AddForeignKey(
             name: "FK_Users_Roles_RoleId",
             table: "Users",
             column: "RoleId",
             principalTable: "Roles",
             principalColumn: "Id",
             onDelete: ReferentialAction.Cascade);
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropForeignKey(
             name: "FK_Users_Roles_RoleId",
             table: "Users");

         migrationBuilder.DropPrimaryKey(
             name: "PK_Roles",
             table: "Roles");

         migrationBuilder.RenameTable(
             name: "Roles",
             newName: "ApplicationRole");

         migrationBuilder.AddPrimaryKey(
             name: "PK_ApplicationRole",
             table: "ApplicationRole",
             column: "Id");

         migrationBuilder.AddForeignKey(
             name: "FK_Users_ApplicationRole_RoleId",
             table: "Users",
             column: "RoleId",
             principalTable: "ApplicationRole",
             principalColumn: "Id",
             onDelete: ReferentialAction.Cascade);
      }
   }
}
