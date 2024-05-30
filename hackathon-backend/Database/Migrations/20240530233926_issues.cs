using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class issues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Issues",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProfileId",
                table: "Issues",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Issues",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ProfileId",
                table: "Issues",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_ParticipantProfiles_ProfileId",
                table: "Issues",
                column: "ProfileId",
                principalTable: "ParticipantProfiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_ParticipantProfiles_ProfileId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_ProfileId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Issues");
        }
    }
}
