using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace webtest.Models
{
    public partial class TrainingContext : DbContext
    {
        public TrainingContext()
            : base("name=TrainingContext1")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseDetail> CourseDetails { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<TrainingStaff> TrainingStaffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Admins)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.account_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Trainees)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.account_detail_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Trainers)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.TrainingStaffs)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.account_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.course_id)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.course_name)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.desription)
                .IsFixedLength();

            modelBuilder.Entity<Course>()
                .HasMany(e => e.CourseDetails)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Topics)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CourseDetail>()
                .Property(e => e.course_id)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.course_id)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.course_id)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .HasMany(e => e.CourseDetails)
                .WithRequired(e => e.Trainee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainer>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Trainer)
                .WillCascadeOnDelete(false);
        }
    }
}
