using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationServer.DAL.Migrations
{
   public partial class addedRole : Migration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.AddColumn<int>(
             name: "RoleId",
             table: "Users",
             type: "int",
             nullable: false,
             defaultValue: 0);

         migrationBuilder.CreateTable(
             name: "ApplicationRole",
             columns: table => new
             {
                RoleId = table.Column<int>(type: "int", nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
             },
             constraints: table =>
             {
                table.PrimaryKey("PK_ApplicationRole", x => x.RoleId);
             });

         migrationBuilder.CreateIndex(
             name: "IX_Users_RoleId",
             table: "Users",
             column: "RoleId");

         migrationBuilder.AddForeignKey(
             name: "FK_Users_ApplicationRole_RoleId",
             table: "Users",
             column: "RoleId",
             principalTable: "ApplicationRole",
             principalColumn: "RoleId",
             onDelete: ReferentialAction.Cascade);
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropForeignKey(
             name: "FK_Users_ApplicationRole_RoleId",
             table: "Users");

         migrationBuilder.DropTable(
             name: "ApplicationRole");

         migrationBuilder.DropIndex(
             name: "IX_Users_RoleId",
             table: "Users");

         migrationBuilder.DropColumn(
             name: "RoleId",
             table: "Users");
      }
   }
}
