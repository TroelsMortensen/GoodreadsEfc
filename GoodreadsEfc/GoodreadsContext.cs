using System;
using System.Collections.Generic;
using GoodreadsEfc.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodreadsEfc;

public partial class GoodreadsContext : DbContext
{
    public GoodreadsContext()
    {
    }

    public GoodreadsContext(DbContextOptions<GoodreadsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Binding> Bindings { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BooksCurrentlyBeingRead> BooksCurrentlyBeingReads { get; set; }

    public virtual DbSet<BooksRead> BooksReads { get; set; }

    public virtual DbSet<BooksWantedToBeRead> BooksWantedToBeReads { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source = C:\\TRMO\\RiderProjects\\GoodreadsEfc\\GoodreadsEfc\\Goodreads.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasIndex(e => new { e.CityName, e.CityPostCode }, "IX_Addresses_CityName_CityPostCode");

            entity.HasIndex(e => e.PublisherId, "IX_Addresses_PublisherId").IsUnique();

            entity.HasOne(d => d.Publisher).WithOne(p => p.Address).HasForeignKey<Address>(d => d.PublisherId);

            entity.HasOne(d => d.City).WithMany(p => p.Addresses).HasForeignKey(d => new { d.CityName, d.CityPostCode });
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasIndex(e => e.WrittenById, "IX_Announcements_WrittenById");

            entity.HasOne(d => d.WrittenBy).WithMany(p => p.Announcements).HasForeignKey(d => d.WrittenById);

            entity.HasMany(d => d.LikedByProfilesProfileNames).WithMany(p => p.AnnouncementsLikeds)
                .UsingEntity<Dictionary<string, object>>(
                    "AnnouncementLike",
                    r => r.HasOne<Profile>().WithMany().HasForeignKey("LikedByProfilesProfileName"),
                    l => l.HasOne<Announcement>().WithMany().HasForeignKey("AnnouncementsLikedId"),
                    j =>
                    {
                        j.HasKey("AnnouncementsLikedId", "LikedByProfilesProfileName");
                        j.ToTable("AnnouncementLikes");
                        j.HasIndex(new[] { "LikedByProfilesProfileName" }, "IX_AnnouncementLikes_LikedByProfilesProfileName");
                    });
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasIndex(e => e.BindingId, "IX_Books_BindingId");

            entity.HasIndex(e => e.PublishedById, "IX_Books_PublishedById");

            entity.HasIndex(e => e.WrittenById, "IX_Books_WrittenById");

            entity.HasOne(d => d.Binding).WithMany(p => p.Books).HasForeignKey(d => d.BindingId);

            entity.HasOne(d => d.PublishedBy).WithMany(p => p.Books).HasForeignKey(d => d.PublishedById);

            entity.HasOne(d => d.WrittenBy).WithMany(p => p.Books).HasForeignKey(d => d.WrittenById);

            entity.HasMany(d => d.CoAuthors).WithMany(p => p.BooksCoAuthoreds)
                .UsingEntity<Dictionary<string, object>>(
                    "AuthorBook",
                    r => r.HasOne<Author>().WithMany().HasForeignKey("CoAuthorsId"),
                    l => l.HasOne<Book>().WithMany().HasForeignKey("BooksCoAuthoredId"),
                    j =>
                    {
                        j.HasKey("BooksCoAuthoredId", "CoAuthorsId");
                        j.ToTable("AuthorBook");
                        j.HasIndex(new[] { "CoAuthorsId" }, "IX_AuthorBook_CoAuthorsId");
                    });

            entity.HasMany(d => d.Genres).WithMany(p => p.DescribedBooks)
                .UsingEntity<Dictionary<string, object>>(
                    "BookGenre",
                    r => r.HasOne<Genre>().WithMany().HasForeignKey("GenresId"),
                    l => l.HasOne<Book>().WithMany().HasForeignKey("DescribedBooksId"),
                    j =>
                    {
                        j.HasKey("DescribedBooksId", "GenresId");
                        j.ToTable("BookGenre");
                        j.HasIndex(new[] { "GenresId" }, "IX_BookGenre_GenresId");
                    });
        });

        modelBuilder.Entity<BooksCurrentlyBeingRead>(entity =>
        {
            entity.HasKey(e => new { e.BookId, e.ProfileName });

            entity.ToTable("BooksCurrentlyBeingRead");

            entity.HasIndex(e => e.ProfileName, "IX_BooksCurrentlyBeingRead_ProfileName");

            entity.HasOne(d => d.Book).WithMany(p => p.BooksCurrentlyBeingReads).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.ProfileNameNavigation).WithMany(p => p.BooksCurrentlyBeingReads).HasForeignKey(d => d.ProfileName);
        });

        modelBuilder.Entity<BooksRead>(entity =>
        {
            entity.HasKey(e => new { e.BookId, e.ProfileName });

            entity.ToTable("BooksRead");

            entity.HasIndex(e => e.ProfileName, "IX_BooksRead_ProfileName");

            entity.HasOne(d => d.Book).WithMany(p => p.BooksReads).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.ProfileNameNavigation).WithMany(p => p.BooksReads).HasForeignKey(d => d.ProfileName);
        });

        modelBuilder.Entity<BooksWantedToBeRead>(entity =>
        {
            entity.HasKey(e => new { e.BookId, e.ProfileName });

            entity.ToTable("BooksWantedToBeRead");

            entity.HasIndex(e => e.ProfileName, "IX_BooksWantedToBeRead_ProfileName");

            entity.HasOne(d => d.Book).WithMany(p => p.BooksWantedToBeReads).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.ProfileNameNavigation).WithMany(p => p.BooksWantedToBeReads).HasForeignKey(d => d.ProfileName);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => new { e.Name, e.PostCode });
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ProfileName);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
