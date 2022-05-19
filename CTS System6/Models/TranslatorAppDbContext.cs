using CTS_System6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Data.Migrations
{
    public class TranslatorAppDbContext : DbContext
    {

    public TranslatorAppDbContext(DbContextOptions<TranslatorAppDbContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bids>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<Languages>()
                .HasKey(l => l.Id);
            modelBuilder.Entity<Rate>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<Projects>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<TranslatorsLanguages>()
                 .HasKey(t => t.Id);


            modelBuilder.Entity<TranslatorsLanguages>()
                .HasOne(p => p.Languages)
                .WithMany(b => b.TranslatorsLanguagesList)
                .HasForeignKey(b => b.FromLanguage);

            modelBuilder.Entity<TranslatorsLanguages>()
                .HasOne(p => p.Languages)
                .WithMany(b => b.TranslatorsLanguagesList)
                .HasForeignKey(b => b.ToLanguage);

            modelBuilder.Entity<TranslatorsLanguages>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(b => b.TranslatorLanguagesList)
                .HasForeignKey(b => b.TranslatorId);

            modelBuilder.Entity<Projects>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(b => b.ProjectsList)
                .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<Projects>()
                .HasOne(p => p.Languages)
                .WithMany(b => b.ProjectsList)
                .HasForeignKey(b => b.FromLanguage);

            modelBuilder.Entity<Projects>()
                .HasOne(p => p.Languages)
                .WithMany(b => b.ProjectsList)
                .HasForeignKey(b => b.ToLanguage);

            modelBuilder.Entity<Rate>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(b => b.RateList)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Bids>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(b => b.BidsList)
                .HasForeignKey(b => b.TranslatorId);

            modelBuilder.Entity<Bids>()
                .HasOne(p => p.Projects)
                .WithMany(b => b.BidsList)
                .HasForeignKey(b => b.ProjectId);
        }


        public DbSet<Languages> Languages { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Rate> Rate { get; set; }
        public DbSet<TranslatorsLanguages> TranslatorsLanguages { get; set; }
        public DbSet<Bids> Bids { get; set; }

    }
}
