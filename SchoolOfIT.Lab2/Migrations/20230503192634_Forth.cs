using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolOfIT.Lab2.Migrations
{
    /// <inheritdoc />
    public partial class Forth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelationTables_Classes_FK_ClassId",
                table: "RelationTables");

            migrationBuilder.DropForeignKey(
                name: "FK_RelationTables_Courses_FK_CourseId",
                table: "RelationTables");

            migrationBuilder.DropForeignKey(
                name: "FK_RelationTables_Students_FK_StudentId",
                table: "RelationTables");

            migrationBuilder.DropForeignKey(
                name: "FK_RelationTables_Teachers_FK_TeacherId",
                table: "RelationTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelationTables",
                table: "RelationTables");

            migrationBuilder.RenameTable(
                name: "RelationTables",
                newName: "Relations");

            migrationBuilder.RenameIndex(
                name: "IX_RelationTables_FK_TeacherId",
                table: "Relations",
                newName: "IX_Relations_FK_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_RelationTables_FK_StudentId",
                table: "Relations",
                newName: "IX_Relations_FK_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_RelationTables_FK_CourseId",
                table: "Relations",
                newName: "IX_Relations_FK_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_RelationTables_FK_ClassId",
                table: "Relations",
                newName: "IX_Relations_FK_ClassId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relations",
                table: "Relations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Classes_FK_ClassId",
                table: "Relations",
                column: "FK_ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Courses_FK_CourseId",
                table: "Relations",
                column: "FK_CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Students_FK_StudentId",
                table: "Relations",
                column: "FK_StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Teachers_FK_TeacherId",
                table: "Relations",
                column: "FK_TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Classes_FK_ClassId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Courses_FK_CourseId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Students_FK_StudentId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Teachers_FK_TeacherId",
                table: "Relations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relations",
                table: "Relations");

            migrationBuilder.RenameTable(
                name: "Relations",
                newName: "RelationTables");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_FK_TeacherId",
                table: "RelationTables",
                newName: "IX_RelationTables_FK_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_FK_StudentId",
                table: "RelationTables",
                newName: "IX_RelationTables_FK_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_FK_CourseId",
                table: "RelationTables",
                newName: "IX_RelationTables_FK_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_FK_ClassId",
                table: "RelationTables",
                newName: "IX_RelationTables_FK_ClassId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelationTables",
                table: "RelationTables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RelationTables_Classes_FK_ClassId",
                table: "RelationTables",
                column: "FK_ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelationTables_Courses_FK_CourseId",
                table: "RelationTables",
                column: "FK_CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelationTables_Students_FK_StudentId",
                table: "RelationTables",
                column: "FK_StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelationTables_Teachers_FK_TeacherId",
                table: "RelationTables",
                column: "FK_TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
