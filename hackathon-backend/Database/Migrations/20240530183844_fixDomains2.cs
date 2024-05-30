using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class fixDomains2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssuesToDomains");

            migrationBuilder.DropTable(
                name: "MentorProfilesToDomains");

            migrationBuilder.AddColumn<string>(
                name: "DomainId",
                table: "Domains",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_DomainId",
                table: "Domains",
                column: "DomainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Domains_Domains_DomainId",
                table: "Domains",
                column: "DomainId",
                principalTable: "Domains",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domains_Domains_DomainId",
                table: "Domains");

            migrationBuilder.DropIndex(
                name: "IX_Domains_DomainId",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "DomainId",
                table: "Domains");

            migrationBuilder.CreateTable(
                name: "IssuesToDomains",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DomainId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IssueId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuesToDomains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssuesToDomains_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssuesToDomains_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MentorProfilesToDomains",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DomainId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MentorId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorProfilesToDomains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MentorProfilesToDomains_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MentorProfilesToDomains_MentorProfiles_MentorId",
                        column: x => x.MentorId,
                        principalTable: "MentorProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_IssuesToDomains_DomainId",
                table: "IssuesToDomains",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_IssuesToDomains_IssueId",
                table: "IssuesToDomains",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorProfilesToDomains_DomainId",
                table: "MentorProfilesToDomains",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorProfilesToDomains_MentorId",
                table: "MentorProfilesToDomains",
                column: "MentorId");
        }
    }
}
