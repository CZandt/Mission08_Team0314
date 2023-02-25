using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission08_Team0314.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskName = table.Column<string>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Quadrant = table.Column<byte>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_tasks_categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "tasks",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "Quadrant", "TaskName" },
                values: new object[] { 3, 1, false, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)3, "Go to Vasa" });

            migrationBuilder.InsertData(
                table: "tasks",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "Quadrant", "TaskName" },
                values: new object[] { 4, 1, false, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)3, "Beat Hogwarts Legacy" });

            migrationBuilder.InsertData(
                table: "tasks",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "Quadrant", "TaskName" },
                values: new object[] { 1, 2, false, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1, "Take 404 Test" });

            migrationBuilder.InsertData(
                table: "tasks",
                columns: new[] { "TaskID", "CategoryID", "Completed", "DueDate", "Quadrant", "TaskName" },
                values: new object[] { 2, 2, false, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)2, "Study for 414 Test" });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_CategoryID",
                table: "tasks",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
