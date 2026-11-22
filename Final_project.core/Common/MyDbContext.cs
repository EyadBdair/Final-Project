using System;
using System.Collections.Generic;
using Final_project.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Core.Common;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Opportunity> Opportunities { get; set; }

    public virtual DbSet<OpportunitySkill> OpportunitySkills { get; set; }

    public virtual DbSet<OpportunityType> OpportunityTypes { get; set; }

    public virtual DbSet<StudentExperiance> StudentExperiances { get; set; }

    public virtual DbSet<StudentProfile> StudentProfiles { get; set; }

    public virtual DbSet<StudentSkill> StudentSkills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=FINAL_PROJECT;Password=12345678;Data Source=localhost:1521/XEPDB1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("FINAL_PROJECT")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("SYS_C008287");

            entity.ToTable("APPLICATIONS");

            entity.HasIndex(e => new { e.UserId, e.OpportunityId }, "UQ_APPLICATION_USER_OPP").IsUnique();

            entity.Property(e => e.ApplicationId)
                .HasColumnType("NUMBER")
                .HasColumnName("APPLICATION_ID");
            entity.Property(e => e.ApplicationDate)
                .HasColumnType("DATE")
                .HasColumnName("APPLICATION_DATE");
            entity.Property(e => e.CoverLetter)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("COVER_LETTER");
            entity.Property(e => e.OpportunityId)
                .HasColumnType("NUMBER")
                .HasColumnName("OPPORTUNITY_ID");
            entity.Property(e => e.StatusId)
                .HasColumnType("NUMBER")
                .HasColumnName("STATUS_ID");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER")
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.Opportunity).WithMany(p => p.Applications)
                .HasForeignKey(d => d.OpportunityId)
                .HasConstraintName("FK_APPLICATION_OPPORTUNITY");

            entity.HasOne(d => d.Status).WithMany(p => p.Applications)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_APPLICATION_STATUS");

            entity.HasOne(d => d.User).WithMany(p => p.Applications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_APPLICATION_USER");
        });

        modelBuilder.Entity<ApplicationStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("SYS_C008258");

            entity.ToTable("APPLICATION_STATUSES");

            entity.Property(e => e.StatusId)
                .HasColumnType("NUMBER")
                .HasColumnName("STATUS_ID");
            entity.Property(e => e.StatusDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("STATUS_DESCRIPTION");
            entity.Property(e => e.StatusName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STATUS_NAME");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("SYS_C008256");

            entity.ToTable("CATEGORIES");

            entity.Property(e => e.CategoryId)
                .HasColumnType("NUMBER")
                .HasColumnName("CATEGORY_ID");
            entity.Property(e => e.CategoryDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CATEGORY_DESCRIPTION");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CATEGORY_NAME");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("COMPANY");

            entity.Property(e => e.Companyid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("COMPANYID");
            entity.Property(e => e.CompanyCreatedAt)
                .HasColumnType("DATE")
                .HasColumnName("COMPANY_CREATED_AT");
            entity.Property(e => e.CompanyDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("COMPANY_DESCRIPTION");
            entity.Property(e => e.CompanyEmail)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("COMPANY_EMAIL");
            entity.Property(e => e.CompanyLocation)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("COMPANY_LOCATION");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("COMPANY_NAME");
            entity.Property(e => e.CompanyPhone)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("COMPANY_PHONE");
            entity.Property(e => e.CompanyWebsite)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("COMPANY_WEBSITE");
        });

        modelBuilder.Entity<Opportunity>(entity =>
        {
            entity.HasKey(e => e.OpportunityId).HasName("SYS_C008279");

            entity.ToTable("OPPORTUNITIES");

            entity.Property(e => e.OpportunityId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("OPPORTUNITY_ID");
            entity.Property(e => e.ApplicationDeadline)
                .HasColumnType("DATE")
                .HasColumnName("APPLICATION_DEADLINE");
            entity.Property(e => e.CategoryId)
                .HasColumnType("NUMBER")
                .HasColumnName("CATEGORY_ID");
            entity.Property(e => e.Companyid)
                .HasColumnType("NUMBER")
                .HasColumnName("COMPANYID");
            entity.Property(e => e.IsFeatured)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("IS_FEATURED");
            entity.Property(e => e.OpportunityDescription)
                .HasColumnType("CLOB")
                .HasColumnName("OPPORTUNITY_DESCRIPTION");
            entity.Property(e => e.OpportunityDuration)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OPPORTUNITY_DURATION");
            entity.Property(e => e.OpportunityLocation)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("OPPORTUNITY_LOCATION");
            entity.Property(e => e.OpportunityStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OPPORTUNITY_STATUS");
            entity.Property(e => e.OpportunityTitle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("OPPORTUNITY_TITLE");
            entity.Property(e => e.OpportunityTypeId)
                .HasColumnType("NUMBER")
                .HasColumnName("OPPORTUNITY_TYPE_ID");
            entity.Property(e => e.Qualifications)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("QUALIFICATIONS");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER")
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.Category).WithMany(p => p.Opportunities)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_CATEGORY_ID");

            entity.HasOne(d => d.Company).WithMany(p => p.Opportunities)
                .HasForeignKey(d => d.Companyid)
                .HasConstraintName("FK_COMPANY_ID");

            entity.HasOne(d => d.OpportunityType).WithMany(p => p.Opportunities)
                .HasForeignKey(d => d.OpportunityTypeId)
                .HasConstraintName("FK_OPPORTUNITY_TYPE_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Opportunities)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_USER_ID");
        });

        modelBuilder.Entity<OpportunitySkill>(entity =>
        {
            entity.HasKey(e => e.OpportunitySkillId).HasName("SYS_C008285");

            entity.ToTable("OPPORTUNITY_SKILLS");

            entity.Property(e => e.OpportunitySkillId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("OPPORTUNITY_SKILL_ID");
            entity.Property(e => e.OpportunityId)
                .HasColumnType("NUMBER")
                .HasColumnName("OPPORTUNITY_ID");
            entity.Property(e => e.OpportunitySkillName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OPPORTUNITY_SKILL_NAME");

            entity.HasOne(d => d.Opportunity).WithMany(p => p.OpportunitySkills)
                .HasForeignKey(d => d.OpportunityId)
                .HasConstraintName("FK_OPPORTUNITY_ID");
        });

        modelBuilder.Entity<OpportunityType>(entity =>
        {
            entity.ToTable("OPPORTUNITY_TYPES");

            entity.Property(e => e.OpportunityTypeId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("OPPORTUNITY_TYPE_ID");
            entity.Property(e => e.OpportunityTypeDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("OPPORTUNITY_TYPE_DESCRIPTION");
            entity.Property(e => e.OpportunityTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OPPORTUNITY_TYPE_NAME");
        });

        modelBuilder.Entity<StudentExperiance>(entity =>
        {
            entity.HasKey(e => e.ExperienceId);

            entity.ToTable("STUDENT_EXPERIANCES");

            entity.Property(e => e.ExperienceId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("EXPERIENCE_ID");
            entity.Property(e => e.ExperienceEnddate)
                .HasColumnType("DATE")
                .HasColumnName("EXPERIENCE_ENDDATE");
            entity.Property(e => e.ExperienceOrganization)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EXPERIENCE_ORGANIZATION");
            entity.Property(e => e.ExperienceStartdate)
                .HasColumnType("DATE")
                .HasColumnName("EXPERIENCE_STARTDATE");
            entity.Property(e => e.ExperienceTitle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EXPERIENCE_TITLE");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.StudentExperiances)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_STUDENT_EXP_USER");
        });

        modelBuilder.Entity<StudentProfile>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("SYS_C008268");

            entity.ToTable("STUDENT_PROFILES");

            entity.HasIndex(e => e.UserId, "SYS_C008269").IsUnique();

            entity.Property(e => e.StudentId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.CvFilePath)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CV_FILE_PATH");
            entity.Property(e => e.GraduationYear)
                .HasPrecision(4)
                .HasColumnName("GRADUATION_YEAR");
            entity.Property(e => e.StudentBio)
                .HasColumnType("CLOB")
                .HasColumnName("STUDENT_BIO");
            entity.Property(e => e.StudentMajor)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("STUDENT_MAJOR");
            entity.Property(e => e.StudentUniversity)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("STUDENT_UNIVERSITY");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER")
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithOne(p => p.StudentProfile)
                .HasForeignKey<StudentProfile>(d => d.UserId)
                .HasConstraintName("FK_STUDENT_USER_ID");
        });

        modelBuilder.Entity<StudentSkill>(entity =>
        {
            entity.ToTable("STUDENT_SKILLS");

            entity.Property(e => e.StudentSkillid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STUDENT_SKILLID");
            entity.Property(e => e.SkillLevel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SKILL_LEVEL");
            entity.Property(e => e.SkillName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SKILL_NAME");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.StudentSkills)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_STUDENT_SKILLS_USER");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("SYS_C008261");

            entity.ToTable("USERS");

            entity.HasIndex(e => e.UserEmail, "SYS_C008262").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("USER_ID");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("USER_EMAIL");
            entity.Property(e => e.UserFullName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("USER_FULL_NAME");
            entity.Property(e => e.UserPasswordHash)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("USER_PASSWORD_HASH");
            entity.Property(e => e.UserPhone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USER_PHONE");
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USER_ROLE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
