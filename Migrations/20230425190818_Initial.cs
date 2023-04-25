using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samit_For_Entertainment.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACTORS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTORS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CINAMAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CINAMAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MOVIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieCategory = table.Column<int>(type: "int", nullable: false),
                    CINAMAID = table.Column<int>(type: "int", nullable: false),
                    PRODUCERID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MOVIES_CINAMAS_CINAMAID",
                        column: x => x.CINAMAID,
                        principalTable: "CINAMAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MOVIES_PRODUCERS_PRODUCERID",
                        column: x => x.PRODUCERID,
                        principalTable: "PRODUCERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ACTORS_MOVIES",
                columns: table => new
                {
                    MOVIEID = table.Column<int>(type: "int", nullable: false),
                    ACTORID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTORS_MOVIES", x => new { x.ACTORID, x.MOVIEID });
                    table.ForeignKey(
                        name: "FK_ACTORS_MOVIES_ACTORS_ACTORID",
                        column: x => x.ACTORID,
                        principalTable: "ACTORS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ACTORS_MOVIES_MOVIES_MOVIEID",
                        column: x => x.MOVIEID,
                        principalTable: "MOVIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACTORS_MOVIES_MOVIEID",
                table: "ACTORS_MOVIES",
                column: "MOVIEID");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIES_CINAMAID",
                table: "MOVIES",
                column: "CINAMAID");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIES_PRODUCERID",
                table: "MOVIES",
                column: "PRODUCERID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACTORS_MOVIES");

            migrationBuilder.DropTable(
                name: "ACTORS");

            migrationBuilder.DropTable(
                name: "MOVIES");

            migrationBuilder.DropTable(
                name: "CINAMAS");

            migrationBuilder.DropTable(
                name: "PRODUCERS");
        }
    }
}
