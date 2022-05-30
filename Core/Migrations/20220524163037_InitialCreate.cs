using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    RevokedOn = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevokedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Guid);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Guid", "Login", "Password", "Name", "Gender", "Birthday", "Admin", "CreateOn", "CreatedBy" },
                values: new object[,]
                {
                    {Guid.NewGuid(), "Admin","123456","Admin",2,DateTime.Now,true, DateTime.Now, "Admin"}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
