using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorSyncfusionCrm.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Longitude = table.Column<double>(type: "REAL", nullable: true),
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
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "TEXT", nullable: true)
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
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateOfBirth", "DateUpdated", "FirstName", "IsDeleted", "LastName", "Latitude", "Longitude", "NickName", "Place" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 9, 21, 5, 34, 647, DateTimeKind.Local).AddTicks(9691), null, new DateTime(2001, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Peter", false, "Parker", null, null, "Spider-man", "New York City" },
                    { 2, new DateTime(2024, 6, 9, 21, 5, 34, 647, DateTimeKind.Local).AddTicks(9743), null, new DateTime(1990, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tony", false, "Stark", null, null, "Iron-man", "Malibu" },
                    { 3, new DateTime(2024, 6, 9, 21, 5, 34, 647, DateTimeKind.Local).AddTicks(9746), null, new DateTime(1990, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bruce", false, "Wayne", null, null, "Batman", "Gotham City" }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "ContactId", "DateCreated", "DateDeleted", "IsDeleted", "Text" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 9, 21, 5, 34, 647, DateTimeKind.Local).AddTicks(9888), null, false, "With great power comes great responsibility" },
                    { 2, 2, new DateTime(2024, 6, 9, 21, 5, 34, 647, DateTimeKind.Local).AddTicks(9891), null, false, "The magic you are searching for is in the work you avoiding" },
                    { 3, 3, new DateTime(2024, 6, 9, 21, 5, 34, 647, DateTimeKind.Local).AddTicks(9893), null, false, "do not care about people" }
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
