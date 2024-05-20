using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorSyncfusionCrm.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    NickName = table.Column<string>(type: "TEXT", nullable: false),
                    Place = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    ContactId = table.Column<int>(type: "INTEGER", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateOfBirth", "DateUpdated", "FirstName", "IsDeleted", "LastName", "NickName", "Place" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 20, 20, 56, 8, 245, DateTimeKind.Local).AddTicks(9272), null, new DateTime(2001, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Peter", null, "Parker", "Spider-man", "New York City" },
                    { 2, new DateTime(2024, 5, 20, 20, 56, 8, 245, DateTimeKind.Local).AddTicks(9333), null, new DateTime(1990, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tony", null, "Stark", "Iron-man", "Malibu" },
                    { 3, new DateTime(2024, 5, 20, 20, 56, 8, 245, DateTimeKind.Local).AddTicks(9338), null, new DateTime(1990, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bruce", null, "Wayne", "Batman", "Gotham City" }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "ContactId", "DateCreated", "Text" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 20, 20, 56, 8, 245, DateTimeKind.Local).AddTicks(9579), "With great power comes great responsibility" },
                    { 2, 2, new DateTime(2024, 5, 20, 20, 56, 8, 245, DateTimeKind.Local).AddTicks(9584), "The magic you are searching for is in the work you avoiding" },
                    { 3, 3, new DateTime(2024, 5, 20, 20, 56, 8, 245, DateTimeKind.Local).AddTicks(9588), "do not care about people" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ContactId",
                table: "Notes",
                column: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
