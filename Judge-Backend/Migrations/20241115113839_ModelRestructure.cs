using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Judge_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ModelRestructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Papers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    AdminID = table.Column<int>(type: "int", nullable: true),
                    TeacherID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Papers_Users_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Users",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Papers_Users_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Papers_Users_TeacherID1",
                        column: x => x.TeacherID1,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    PaperID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => new { x.PaperID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_Enrollment_Papers_PaperID",
                        column: x => x.PaperID,
                        principalTable: "Papers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Enrollment_Users_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Labs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabNumber = table.Column<int>(type: "int", nullable: false),
                    LabName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabInput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabOutput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExampleInput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExampleOutput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaperID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Labs_Papers_PaperID",
                        column: x => x.PaperID,
                        principalTable: "Papers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabSubmissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    source_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutedCorrectly = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    LabID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabSubmissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LabSubmissions_Labs_LabID",
                        column: x => x.LabID,
                        principalTable: "Labs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabSubmissions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollment",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Labs_PaperID",
                table: "Labs",
                column: "PaperID");

            migrationBuilder.CreateIndex(
                name: "IX_LabSubmissions_LabID",
                table: "LabSubmissions",
                column: "LabID");

            migrationBuilder.CreateIndex(
                name: "IX_LabSubmissions_UserID",
                table: "LabSubmissions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Papers_AdminID",
                table: "Papers",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Papers_TeacherID",
                table: "Papers",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Papers_TeacherID1",
                table: "Papers",
                column: "TeacherID1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "LabSubmissions");

            migrationBuilder.DropTable(
                name: "Labs");

            migrationBuilder.DropTable(
                name: "Papers");
        }
    }
}
