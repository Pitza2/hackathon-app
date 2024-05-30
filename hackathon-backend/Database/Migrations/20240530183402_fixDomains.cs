using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class fixDomains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domains_Issues_IssueId",
                table: "Domains");

            migrationBuilder.DropForeignKey(
                name: "FK_Domains_MentorProfiles_MentorProfileId",
                table: "Domains");

            migrationBuilder.DropIndex(
                name: "IX_Domains_IssueId",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "IssueId",
                table: "Domains");

            migrationBuilder.RenameColumn(
                name: "MentorProfileId",
                table: "Domains",
                newName: "ParticipantProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Domains_MentorProfileId",
                table: "Domains",
                newName: "IX_Domains_ParticipantProfileId");

            migrationBuilder.AddColumn<bool>(
                name: "IsSolved",
                table: "Issues",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DomainIssue",
                columns: table => new
                {
                    DomainsId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IssuesId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainIssue", x => new { x.DomainsId, x.IssuesId });
                    table.ForeignKey(
                        name: "FK_DomainIssue_Domains_DomainsId",
                        column: x => x.DomainsId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainIssue_Issues_IssuesId",
                        column: x => x.IssuesId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DomainMentorProfile",
                columns: table => new
                {
                    DomainsId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MentorProfilesId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainMentorProfile", x => new { x.DomainsId, x.MentorProfilesId });
                    table.ForeignKey(
                        name: "FK_DomainMentorProfile_Domains_DomainsId",
                        column: x => x.DomainsId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainMentorProfile_MentorProfiles_MentorProfilesId",
                        column: x => x.MentorProfilesId,
                        principalTable: "MentorProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DomainIssue_IssuesId",
                table: "DomainIssue",
                column: "IssuesId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainMentorProfile_MentorProfilesId",
                table: "DomainMentorProfile",
                column: "MentorProfilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Domains_ParticipantProfiles_ParticipantProfileId",
                table: "Domains",
                column: "ParticipantProfileId",
                principalTable: "ParticipantProfiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domains_ParticipantProfiles_ParticipantProfileId",
                table: "Domains");

            migrationBuilder.DropTable(
                name: "DomainIssue");

            migrationBuilder.DropTable(
                name: "DomainMentorProfile");

            migrationBuilder.DropColumn(
                name: "IsSolved",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "ParticipantProfileId",
                table: "Domains",
                newName: "MentorProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Domains_ParticipantProfileId",
                table: "Domains",
                newName: "IX_Domains_MentorProfileId");

            migrationBuilder.AddColumn<string>(
                name: "IssueId",
                table: "Domains",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_IssueId",
                table: "Domains",
                column: "IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Domains_Issues_IssueId",
                table: "Domains",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Domains_MentorProfiles_MentorProfileId",
                table: "Domains",
                column: "MentorProfileId",
                principalTable: "MentorProfiles",
                principalColumn: "Id");
        }
    }
}
