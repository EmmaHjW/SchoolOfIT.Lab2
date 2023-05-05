using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolOfIT.Lab2.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Courses_FK_CourseId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Students_FK_StudentId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_FK_TeacherId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_FK_CourseId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_FK_StudentId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_FK_TeacherId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "FK_CourseId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "FK_StudentId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "FK_TeacherId",
                table: "Classes");

            migrationBuilder.CreateTable(
                name: "RelationTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_StudentId = table.Column<int>(type: "int", nullable: false),
                    FK_TeacherId = table.Column<int>(type: "int", nullable: false),
                    FK_CourseId = table.Column<int>(type: "int", nullable: false),
                    FK_ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelationTables_Classes_FK_ClassId",
                        column: x => x.FK_ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelationTables_Courses_FK_CourseId",
                        column: x => x.FK_CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelationTables_Students_FK_StudentId",
                        column: x => x.FK_StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelationTables_Teachers_FK_TeacherId",
                        column: x => x.FK_TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelationTables_FK_ClassId",
                table: "RelationTables",
                column: "FK_ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_RelationTables_FK_CourseId",
                table: "RelationTables",
                column: "FK_CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_RelationTables_FK_StudentId",
                table: "RelationTables",
                column: "FK_StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RelationTables_FK_TeacherId",
                table: "RelationTables",
                column: "FK_TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelationTables");

            migrationBuilder.AddColumn<int>(
                name: "FK_CourseId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FK_StudentId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FK_TeacherId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_FK_CourseId",
                table: "Classes",
                column: "FK_CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_FK_StudentId",
                table: "Classes",
                column: "FK_StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_FK_TeacherId",
                table: "Classes",
                column: "FK_TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Courses_FK_CourseId",
                table: "Classes",
                column: "FK_CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Students_FK_StudentId",
                table: "Classes",
                column: "FK_StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Teachers_FK_TeacherId",
                table: "Classes",
                column: "FK_TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
