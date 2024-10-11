using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScoreAnnouncementAPI.Models.Entities;

namespace ScoreAnnouncementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Exam> Exam { get; set; } = default!;
        public DbSet<Student> Student { get; set; } = default!;
        public DbSet<StudentExam> StudentExam { get; set; } = default!;
        public DbSet<ITStudent> ITStudent { get; set; } = default!;
        public DbSet<ScoreFL> ScoreFL { get; set; } = default!;
        public DbSet<ScoreIT> ScoreIT { get; set; } = default!;
        public DbSet<ConvertForm> ConvertForms { get; set; } = default!;
        public DbSet<RequireForm> RequireForms { get; set; } = default!;
        public DbSet<ExamType> ExamType { get; set; } = default!;

    }
}
