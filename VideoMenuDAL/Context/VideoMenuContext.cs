using Microsoft.EntityFrameworkCore;
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

        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
