﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolOfIT.Lab2.Data;

#nullable disable

namespace SchoolOfIT.Lab2.Migrations
{
    [DbContext(typeof(SchoolOfITContext))]
    partial class SchoolOfITContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolOfIT.Lab2.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("SchoolOfIT.Lab2.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SchoolOfIT.Lab2.Models.RelationTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FK_ClassId")
                        .HasColumnType("int");

                    b.Property<int>("FK_CourseId")
                        .HasColumnType("int");

                    b.Property<int>("FK_StudentId")
                        .HasColumnType("int");

                    b.Property<int>("FK_TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FK_ClassId");

                    b.HasIndex("FK_CourseId");

                    b.HasIndex("FK_StudentId");

                    b.HasIndex("FK_TeacherId");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("SchoolOfIT.Lab2.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolOfIT.Lab2.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolOfIT.Lab2.Models.RelationTable", b =>
                {
                    b.HasOne("SchoolOfIT.Lab2.Models.Class", "Classes")
                        .WithMany("Relations")
                        .HasForeignKey("FK_ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolOfIT.Lab2.Models.Course", "Courses")
                        .WithMany("Relations")
                        .HasForeignKey("FK_CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolOfIT.Lab2.Models.Student", "Students")
                        .WithMany("Relations")
                        .HasForeignKey("FK_StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolOfIT.Lab2.Models.Teacher", "Teachers")
                        .WithMany("Relations")
                        .HasForeignKey("FK_TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classes");

                    b.Navigation("Courses");

                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("SchoolOfIT.Lab2.Models.Class", b =>
                {
                    b.Navigation("Relations");
                });

            modelBuilder.Entity("SchoolOfIT.Lab2.Models.Course", b =>
                {
                    b.Navigation("Relations");
                });

            modelBuilder.Entity("SchoolOfIT.Lab2.Models.Student", b =>
                {
                    b.Navigation("Relations");
                });

            modelBuilder.Entity("SchoolOfIT.Lab2.Models.Teacher", b =>
                {
                    b.Navigation("Relations");
                });
#pragma warning restore 612, 618
        }
    }
}