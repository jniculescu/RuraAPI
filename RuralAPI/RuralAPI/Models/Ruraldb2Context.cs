using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RuralAPI.Models
{
    public partial class Ruraldb2Context : DbContext
    {
        public Ruraldb2Context()
        {
        }

        public Ruraldb2Context(DbContextOptions<Ruraldb2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionChoice> QuestionChoice { get; set; }
        public virtual DbSet<Summary> Summary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SEIJA-PC\\SQLEXPRESS;Initial Catalog=RuralDB2;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Nationality).IsUnicode(false);

                entity.Property(e => e.Sex).IsUnicode(false);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Title_EN).IsUnicode(false);

                entity.Property(e => e.Title_FI).IsUnicode(false);
            });

            modelBuilder.Entity<QuestionChoice>(entity =>
            {
                entity.Property(e => e.LeftTitle_FI).IsUnicode(false);

                entity.Property(e => e.RightTitle_FI).IsUnicode(false);

                entity.Property(e => e.LeftTitle_EN).IsUnicode(false);

                entity.Property(e => e.RightTitle_EN).IsUnicode(false);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionChoice)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_QuestionChoice_Question");
            });

            modelBuilder.Entity<Summary>(entity =>
            {
                entity.Property(e => e.TimeStamp).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Summary)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Summary_Person");

                entity.HasOne(d => d.QuestionChoise)
                    .WithMany(p => p.Summary)
                    .HasForeignKey(d => d.QuestionChoiseId)
                    .HasConstraintName("FK_Summary_QuestionChoice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}