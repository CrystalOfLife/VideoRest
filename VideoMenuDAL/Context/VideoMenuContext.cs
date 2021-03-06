﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Context
{
    class VideoMenuContext : DbContext
    {
        static DbContextOptions<VideoMenuContext> options =
            new DbContextOptionsBuilder<VideoMenuContext>()
                .UseInMemoryDatabase("TheDB").Options;

        public VideoMenuContext() : base(options)
        {
            
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:video-nul-easv.database.windows.net,1433;Initial Catalog=CS2017_VideoMenu;Persist Security Info=False;User ID=Nicolai;Password=FXA72haw;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGenre>()
                .HasKey(ca => new { ca.GenreId, ca.VideoId });

            modelBuilder.Entity<VideoGenre>()
                .HasOne(ca => ca.Genre)
                .WithMany(g => g.Videoes)
                .HasForeignKey(ca => ca.GenreId);

            modelBuilder.Entity<VideoGenre>()
                .HasOne(ca => ca.Video)
                .WithMany(v => v.Genres)
                .HasForeignKey(ca => ca.VideoId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Video> Videoes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
