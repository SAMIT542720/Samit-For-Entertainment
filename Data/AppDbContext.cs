using Microsoft.EntityFrameworkCore;
using Samit_For_Entertainment.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Samit_For_Entertainment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACTOR_MOVIE>().HasKey(am => new
            {
                am.ACTORID,
                am.MOVIEID,
            });


            modelBuilder.Entity<ACTOR_MOVIE>().HasOne(m => m.MOVIE).WithMany(am => am.ACTORS_MOVIES).HasForeignKey(m => m.MOVIEID);
            modelBuilder.Entity<ACTOR_MOVIE>().HasOne(m => m.ACTOR).WithMany(am => am.ACTORS_MOVIES).HasForeignKey(m => m.ACTORID);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet <ACTOR> ACTORS { get; set; }
        public DbSet<MOVIE> MOVIES { get; set; }
        public DbSet<CINAMA> CINAMAS { get; set; }
        public DbSet<PRODUCER> PRODUCERS { get; set; }
        public DbSet<ACTOR_MOVIE> ACTORS_MOVIES { get; set; }
    }
}
