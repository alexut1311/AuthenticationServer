using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationServer.DAL.Migrations
{
   public partial class addedUserBucketName : Migration
   {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.AddColumn<string>(
             name: "UserBucketName",
             table: "Users",
             type: "nvarchar(max)",
             nullable: false,
             defaultValue: "");
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropColumn(
             name: "UserBucketName",
             table: "Users");
      }
   }
}
