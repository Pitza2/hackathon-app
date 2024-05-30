using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class participantProfiles1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Domains_Domains_DomainId",
                table: "Domains");

            migrationBuilder.DropForeignKey(
                name: "FK_Domains_ParticipantProfiles_ParticipantProfileId",
                table: "Domains");

            migrationBuilder.DropIndex(
                name: "IX_Domains_DomainId",
                table: "Domains");

            migrationBuilder.DropIndex(
                name: "IX_Domains_ParticipantProfileId",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "DomainId",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "ParticipantProfileId",
                table: "Domains");

            migrationBuilder.CreateTable(
                name: "DomainParticipantProfile",
                columns: table => new
                {
                    DomainsId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParticipantProfilesId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainParticipantProfile", x => new { x.DomainsId, x.ParticipantProfilesId });
                    table.ForeignKey(
                        name: "FK_DomainParticipantProfile_Domains_DomainsId",
                        column: x => x.DomainsId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainParticipantProfile_ParticipantProfiles_ParticipantProf~",
                        column: x => x.ParticipantProfilesId,
                        principalTable: "ParticipantProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DomainParticipantProfile_ParticipantProfilesId",
                table: "DomainParticipantProfile",
                column: "ParticipantProfilesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DomainParticipantProfile");

            migrationBuilder.AddColumn<string>(
                name: "DomainId",
                table: "Domains",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ParticipantProfileId",
                table: "Domains",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_DomainId",
                table: "Domains",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_ParticipantProfileId",
                table: "Domains",
                column: "ParticipantProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Domains_Domains_DomainId",
                table: "Domains",
                column: "DomainId",
                principalTable: "Domains",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Domains_ParticipantProfiles_ParticipantProfileId",
                table: "Domains",
                column: "ParticipantProfileId",
                principalTable: "ParticipantProfiles",
                principalColumn: "Id");
        }
    }
}
