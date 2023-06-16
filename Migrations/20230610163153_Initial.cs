using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicatieClinicaAnalize.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoClinica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeClinica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriereClinica = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PozaDeProfilURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeDoctor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DespreDoctor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Analize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeAnaliza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PretAnaliza = table.Column<double>(type: "float", nullable: false),
                    CategorieAnaliza = table.Column<int>(type: "int", nullable: false),
                    ClinicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Analize_Clinici_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctori_Analize",
                columns: table => new
                {
                    AnalizaId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctori_Analize", x => new { x.DoctorId, x.AnalizaId });
                    table.ForeignKey(
                        name: "FK_Doctori_Analize_Analize_AnalizaId",
                        column: x => x.AnalizaId,
                        principalTable: "Analize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctori_Analize_Doctori_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analize_ClinicaId",
                table: "Analize",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctori_Analize_AnalizaId",
                table: "Doctori_Analize",
                column: "AnalizaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctori_Analize");

            migrationBuilder.DropTable(
                name: "Analize");

            migrationBuilder.DropTable(
                name: "Doctori");

            migrationBuilder.DropTable(
                name: "Clinici");
        }
    }
}
