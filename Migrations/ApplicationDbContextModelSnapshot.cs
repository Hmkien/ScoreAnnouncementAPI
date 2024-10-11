﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScoreAnnouncementAPI.Data;

#nullable disable

namespace ScoreAnnouncementAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("ScoreAnnouncementAPI.Models.Entities.ConvertForm", b =>
                {
                    b.Property<int>("ConvertFormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CertificateName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CertificateType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("fileDocx")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ConvertFormId");

                    b.ToTable("ConvertForms");
                });

            modelBuilder.Entity("ScoreAnnouncementAPI.Models.Entities.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatePerson")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ExamCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ExamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ExamTypeId")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("ExamId");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("ScoreAnnouncementAPI.Models.Entities.ExamType", b =>
                {
                    b.Property<string>("ExamTypeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExamTypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ExamTypeId");

                    b.ToTable("ExamType");
                });

            modelBuilder.Entity("ScoreAnnouncementAPI.Models.Entities.ITStudent", b =>
                {
                    b.Property<string>("IdentityNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("BirthDay")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdentificationCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("national")
                        .HasColumnType("TEXT");

                    b.HasKey("IdentityNumber");

                    b.ToTable("ITStudent");
                });

            modelBuilder.Entity("ScoreAnnouncementAPI.Models.Entities.RequireForm", b =>
                {
                    b.Property<int>("RequireFormCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileDocx")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudenCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("StudentCode")
                        .HasColumnType("TEXT");

                    b.HasKey("RequireFormCode");

                    b.HasIndex("StudentCode");

                    b.ToTable("RequireForms");
                });

            modelBuilder.Entity("ScoreAnnouncementAPI.Models.Entities.ScoreFL", b =>
                {
                    b.Property<int>("ScoreFLCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ListeningScore")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReadingScore")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Result")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpeakingScore")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TotalScore")
                        .HasColumnType("TEXT");

                    b.Property<string>("WritingScore")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ScoreFLCode");

                    b.ToTable("ScoreFL");
                });

            modelBuilder.Entity("ScoreAnnouncementAPI.Models.Entities.ScoreIT", b =>
                {
                    b.Property<int>("ScoreITCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExcelScore")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("PowerPointScore")
                        .HasColumnType("TEXT");

                    b.Property<string>("PracticalScore")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Result")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("TheoryScore")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TotalScore")
                        .HasColumnType("TEXT");

                    b.Property<string>("WordScore")
                        .HasColumnType("TEXT");

                    b.Property<int>("examId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ScoreITCode");

                    b.ToTable("ScoreIT");
                });

            modelBuilder.Entity("ScoreAnnouncementAPI.Models.Entities.Student", b =>
                {
                    b.Property<string>("StudentCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Course")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Faculty")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Note")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("StudentCode");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("ScoreAnnouncementAPI.Models.Entities.StudentExam", b =>
                {
                    b.Property<Guid>("StudentExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ITStudentIdentityNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentCode")
                        .HasColumnType("TEXT");

                    b.HasKey("StudentExamId");

                    b.HasIndex("ITStudentIdentityNumber");

                    b.HasIndex("StudentCode");

                    b.ToTable("StudentExam");
                });

            modelBuilder.Entity("ScoreAnnouncementAPI.Models.Entities.RequireForm", b =>
                {
                    b.HasOne("ScoreAnnouncementAPI.Models.Entities.StudentExam", "StudentExam")
                        .WithMany()
                        .HasForeignKey("StudentCode");

                    b.Navigation("StudentExam");
                });

            modelBuilder.Entity("ScoreAnnouncementAPI.Models.Entities.StudentExam", b =>
                {
                    b.HasOne("ScoreAnnouncementAPI.Models.Entities.ITStudent", "ITStudent")
                        .WithMany()
                        .HasForeignKey("ITStudentIdentityNumber");

                    b.HasOne("ScoreAnnouncementAPI.Models.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentCode");

                    b.Navigation("ITStudent");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
