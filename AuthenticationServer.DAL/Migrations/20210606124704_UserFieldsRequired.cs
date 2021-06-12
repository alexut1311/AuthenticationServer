using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationServer.DAL.Migrations
{
   public partial class UserFieldsRequired : Migration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.AlterColumn<string>(
             name: "Username",
             table: "Users",
             type: "nvarchar(max)",
             nullable: false,
             defaultValue: "",
             oldClrType: typeof(string),
             oldType: "nvarchar(max)",
             oldNullable: true);

         migrationBuilder.AlterColumn<string>(
             name: "Password",
             table: "Users",
             type: "nvarchar(max)",
             nullable: false,
             defaultValue: "",
             oldClrType: typeof(string),
             oldType: "nvarchar(max)",
             oldNullable: true);

         migrationBuilder.AlterColumn<string>(
             name: "LastName",
             table: "Users",
             type: "nvarchar(max)",
             nullable: false,
             defaultValue: "",
             oldClrType: typeof(string),
             oldType: "nvarchar(max)",
             oldNullable: true);

         migrationBuilder.AlterColumn<string>(
             name: "FirstName",
             table: "Users",
             type: "nvarchar(max)",
             nullable: false,
             defaultValue: "",
             oldClrType: typeof(string),
             oldType: "nvarchar(max)",
             oldNullable: true);

         migrationBuilder.AlterColumn<string>(
             name: "Email",
             table: "Users",
             type: "nvarchar(max)",
             nullable: false,
             defaultValue: "",
             oldClrType: typeof(string),
             oldType: "nvarchar(max)",
             oldNullable: true);
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.AlterColumn<string>(
             name: "Username",
             table: "Users",
             type: "nvarchar(max)",
             nullable: true,
             oldClrType: typeof(string),
             oldType: "nvarchar(max)");

         migrationBuilder.AlterColumn<string>(
             name: "Password",
             table: "Users",
             type: "nvarchar(max)",
             nullable: true,
             oldClrType: typeof(string),
             oldType: "nvarchar(max)");

         migrationBuilder.AlterColumn<string>(
             name: "LastName",
             table: "Users",
             type: "nvarchar(max)",
             nullable: true,
             oldClrType: typeof(string),
             oldType: "nvarchar(max)");

         migrationBuilder.AlterColumn<string>(
             name: "FirstName",
             table: "Users",
             type: "nvarchar(max)",
             nullable: true,
             oldClrType: typeof(string),
             oldType: "nvarchar(max)");

         migrationBuilder.AlterColumn<string>(
             name: "Email",
             table: "Users",
             type: "nvarchar(max)",
             nullable: true,
             oldClrType: typeof(string),
             oldType: "nvarchar(max)");
      }
   }
}
