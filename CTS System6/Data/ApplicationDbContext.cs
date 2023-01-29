using CTS_System6.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CTS_System6.ViewModels;

namespace CTS_System6.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<string>>().ToTable("Userlogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            builder.Entity<Bids>()
                       .HasKey(b => b.Id);
            builder.Entity<Languages>()
                .HasKey(l => l.Id);
            builder.Entity<Rate>()
                .HasKey(r => r.Id);
            builder.Entity<Projects>()
                .HasKey(p => p.Id);
            builder.Entity<TranslatorsLanguages>()
                 .HasKey(t => t.Id);

            //translator languages --- languages (from)
            builder.Entity<TranslatorsLanguages>()
                .HasOne(p => p.FromLanguage)
                .WithMany(b => b.TFromLanguages)
                .HasForeignKey(b => b.FromLanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            //translator languages --- languages (to)
            builder.Entity<TranslatorsLanguages>()
                .HasOne(p => p.ToLanguage)
                .WithMany(b => b.TToLanguages)
                .HasForeignKey(b => b.ToLanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TranslatorsLanguages>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(b => b.TranslatorLanguagesList)
                .HasForeignKey(b => b.TranslatorId);

            builder.Entity<Projects>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(b => b.ProjectsList)
                .HasForeignKey(b => b.CustomerId);

            //projects --- languages (from)
            builder.Entity<Projects>()
                .HasOne(p => p.FromLanguage)
                .WithMany(b => b.PFromLanguages)
                .HasForeignKey(b => b.FromLanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            //translator languages --- languages (to)
            builder.Entity<Projects>()
                .HasOne(p => p.ToLanguage)
                .WithMany(b => b.PToLanguages)
                .HasForeignKey(b => b.ToLanguageId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Bids>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(b => b.BidsList)
                .HasForeignKey(b => b.TranslatorId);

            builder.Entity<Bids>()
                .HasOne(p => p.Projects)
                .WithMany(b => b.BidsList)
                .HasForeignKey(b => b.ProjectId);

            builder.Entity<ChatRoom>()
                .HasOne(c => c.UserA)
                .WithMany(c => c.UserAChatRoom)
                .HasForeignKey(c => c.UserAId);
            builder.Entity<ChatRoom>()
                .HasOne(c => c.UserB)
                .WithMany(c => c.UserBChatRoom)
                .HasForeignKey(c => c.UserBId);
            builder.Entity<ChatRoom>()
                .HasKey(c => c.Id);
            builder.Entity<Message>()
                .HasKey(m => m.Id);
            builder.Entity<Message>()
                .HasOne(m => m.ChatRoom)
                .WithMany(m => m.Messages)
                .HasForeignKey(m => m.ChatRoomId);

        }


        public DbSet<Languages> Languages { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Rate> Rate { get; set; }
        public DbSet<TranslatorsLanguages> TranslatorsLanguages { get; set; }
        public DbSet<Bids> Bids { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Message> Messages { get; set; }



    }
}
