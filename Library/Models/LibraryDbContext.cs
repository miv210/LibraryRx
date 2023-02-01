using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library.Models;

public partial class LibraryDbContext : DbContext
{
    public LibraryDbContext()
    {
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<IssuanceOfBook> IssuanceOfBooks { get; set; }

    public virtual DbSet<Reader> Readers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=LibraryDb;Username=postgres;Password=25riboza25");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Book_pkey");

            entity.ToTable("Book");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ArticleNumber).HasColumnName("Article_number");
            entity.Property(e => e.Author).HasColumnType("character varying");
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.NumberOfInstances).HasColumnName("Number_of_instances");
            entity.Property(e => e.YearOfPublication).HasColumnName("Year_of_publication");
        });

        modelBuilder.Entity<IssuanceOfBook>(entity =>
        {
            entity.HasKey(e => e.IdReader).HasName("Issuance_of_books_pkey");

            entity.ToTable("Issuance_of_books");

            entity.Property(e => e.IdReader)
                .ValueGeneratedNever()
                .HasColumnName("id_reader");
            entity.Property(e => e.DateOfIssue).HasColumnName("Date_of_issue");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdBook).HasColumnName("id_book");
            entity.Property(e => e.ReturnDate).HasColumnName("Return_date");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.IssuanceOfBooks)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Issuance_book");

            entity.HasOne(d => d.IdReaderNavigation).WithOne(p => p.IssuanceOfBook)
                .HasForeignKey<IssuanceOfBook>(d => d.IdReader)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Issuance_reader");
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Reader_pkey");

            entity.ToTable("Reader");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Fullname).HasColumnType("character varying");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
