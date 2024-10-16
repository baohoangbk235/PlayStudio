﻿using Microsoft.EntityFrameworkCore;
using PlayStudio.Server.Model;

namespace PlayStudio.Server.Context
{
      public class PlayStudioContext : DbContext
      {
            public DbSet<GameClub> Clubs { get; set; }

            public DbSet<ClubEvent> Events { get; set; }

            public PlayStudioContext(DbContextOptions<PlayStudioContext> options, IConfiguration configuration) : base(options)
            {
                  
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                  modelBuilder.Entity<GameClub>()
                      .HasMany(e => e.Events)
                      .WithOne(e => e.Club)
                      .HasForeignKey(e => e.ClubId)
                      .HasPrincipalKey(e => e.Id);
            }
      }
}
