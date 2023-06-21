using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentProject.Models;

public partial class SchoolDbContext : DbContext
{
    public virtual DbSet<Marks> Marks { get; set; }

    public virtual DbSet<Student> Students { get; set; }


    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
    {

    }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-5219HOI;Initial Catalog=SchoolDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marks>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Marks__3214EC0708924A3F");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.StudentId).HasColumnName("StudentId");

            entity.HasOne(d => d.Student).WithMany(p => p.Marks)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Marks__StudentId__164452B1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC0771A4C800");

            entity.ToTable("Student");

            entity.Property(e => e.Class)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DOB).HasColumnType("date");
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
