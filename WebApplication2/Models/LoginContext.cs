using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class LoginContext : DbContext
{
    public LoginContext()
    {
    }

    public LoginContext(DbContextOptions<LoginContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articletable> Articletables { get; set; }

    public virtual DbSet<Logintable> Logintables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=login;TrustServerCertificate=true;Trusted_Connection=True;User ID=sa;Password=123456789");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articletable>(entity =>
        {
            entity.HasKey(e => e.RowId).HasName("PK__articlet__6965AB57F8C0A0D0");

            entity.ToTable("articletable");

            entity.Property(e => e.RowId).HasColumnName("row_id");
            entity.Property(e => e.PostAccount)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Post_Account");
            entity.Property(e => e.PostContent)
                .IsUnicode(false)
                .HasColumnName("Post_Content");
            entity.Property(e => e.PostDatetime)
                .HasColumnType("datetime")
                .HasColumnName("Post_Datetime");
            entity.Property(e => e.PostTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Post_Title");
        });

        modelBuilder.Entity<Logintable>(entity =>
        {
            entity.HasKey(e => e.RowId);

            entity.ToTable("logintable");

            entity.Property(e => e.RowId).HasColumnName("row_id");
            entity.Property(e => e.Account)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("account");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
