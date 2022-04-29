using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Deadline.Models
{
    public partial class DeadlineContext : DbContext
    {
        public DeadlineContext()
        {
        }

        public DeadlineContext(DbContextOptions<DeadlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<AnswerPhoto> AnswerPhotos { get; set; } = null!;
        public virtual DbSet<AnswerReason> AnswerReasons { get; set; } = null!;
        public virtual DbSet<AnswerType> AnswerTypes { get; set; } = null!;
        public virtual DbSet<Audit> Audits { get; set; } = null!;
        public virtual DbSet<AuditCategory> AuditCategories { get; set; } = null!;
        public virtual DbSet<AuditPeriod> AuditPeriods { get; set; } = null!;
        public virtual DbSet<AuditStatus> AuditStatuses { get; set; } = null!;
        public virtual DbSet<AuditType> AuditTypes { get; set; } = null!;
        public virtual DbSet<AuditsUsersRel> AuditsUsersRels { get; set; } = null!;
        public virtual DbSet<Checklist> Checklists { get; set; } = null!;
        public virtual DbSet<ChecklistType> ChecklistTypes { get; set; } = null!;
        public virtual DbSet<ContactPerson> ContactPersons { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerBranch> CustomerBranches { get; set; } = null!;
        public virtual DbSet<CustomerRegion> CustomerRegions { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<QuestionCategory> QuestionCategories { get; set; } = null!;
        public virtual DbSet<QuestionTag> QuestionTags { get; set; } = null!;
        public virtual DbSet<QuestionType> QuestionTypes { get; set; } = null!;
        public virtual DbSet<Reason> Reasons { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserType> UserTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.\\SQLExpress; database=Deadline; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Turkmen_100_CI_AS");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Answer1).HasColumnName("Answer");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Answer1Navigation)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.Answer1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answers_AnswerTypes");

                entity.HasOne(d => d.Audit)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.AuditId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answers_Audits");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answers_Questions");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answers_Users");
            });

            modelBuilder.Entity<AnswerPhoto>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.AnswerPhotos)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnswerPhotos_Answers");
            });

            modelBuilder.Entity<AnswerReason>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.AnswerReasons)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnswerReasons_Answers");

                entity.HasOne(d => d.Reason)
                    .WithMany(p => p.AnswerReasons)
                    .HasForeignKey(d => d.ReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnswerReasons_Reasons");
            });

            modelBuilder.Entity<AnswerType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Audit>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Guid).HasMaxLength(150);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.AuditCategory)
                    .WithMany(p => p.Audits)
                    .HasForeignKey(d => d.AuditCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audits_AuditCategories");

                entity.HasOne(d => d.AuditPeriod)
                    .WithMany(p => p.Audits)
                    .HasForeignKey(d => d.AuditPeriodId)
                    .HasConstraintName("FK_Audits_AuditPeriods");

                entity.HasOne(d => d.AuditStatus)
                    .WithMany(p => p.Audits)
                    .HasForeignKey(d => d.AuditStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audits_AuditStatuses");

                entity.HasOne(d => d.AuditType)
                    .WithMany(p => p.Audits)
                    .HasForeignKey(d => d.AuditTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audits_AuditTypes");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Audits)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audits_CustomerBranches");

                entity.HasOne(d => d.Checklist)
                    .WithMany(p => p.Audits)
                    .HasForeignKey(d => d.ChecklistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audits_Checklists");
            });

            modelBuilder.Entity<AuditCategory>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid).HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AuditCategories)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuditCategories_Customers");
            });

            modelBuilder.Entity<AuditPeriod>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AuditPeriods)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuditPeriods_Customers");
            });

            modelBuilder.Entity<AuditStatus>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<AuditType>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<AuditsUsersRel>(entity =>
            {
                entity.ToTable("AuditsUsersRel");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Audit)
                    .WithMany(p => p.AuditsUsersRels)
                    .HasForeignKey(d => d.AuditId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuditsUsersRel_Audits");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuditsUsersRels)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuditsUsersRel_Users");
            });

            modelBuilder.Entity<Checklist>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.RevisionDate).HasColumnType("date");

                entity.HasOne(d => d.ChecklistType)
                    .WithMany(p => p.Checklists)
                    .HasForeignKey(d => d.ChecklistTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Checklists_ChecklistTypes");
            });

            modelBuilder.Entity<ChecklistType>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<ContactPerson>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.Tel).HasMaxLength(50);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.ContactPeople)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactPersons_CustomerBranches");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<CustomerBranch>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerBranches)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerBranches_Customers");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.CustomerBranches)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerBranches_CustomerRegions");
            });

            modelBuilder.Entity<CustomerRegion>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerRegions)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerRegions_Customers");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Question1).HasColumnName("Question");

                entity.HasOne(d => d.Checklist)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.ChecklistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_Checklists");

                entity.HasOne(d => d.QuestionCategory)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuestionCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_QuestionCategories");

                entity.HasOne(d => d.QuestionTypeNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuestionType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_QuestionTypes");
            });

            modelBuilder.Entity<QuestionCategory>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Checklist)
                    .WithMany(p => p.QuestionCategories)
                    .HasForeignKey(d => d.ChecklistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionCategories_Checklists");
            });

            modelBuilder.Entity<QuestionTag>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Question)
                    .WithMany()
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionTags_Questions");

                entity.HasOne(d => d.Tag)
                    .WithMany()
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionTags_Tags");
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Reason>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Reasons)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reasons_Questions");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_CustomerBranches");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UserTypes");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Guid)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
