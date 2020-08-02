using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<FilmActor> FilmActors { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FilmActor>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<FilmActor>()
                .HasOne(x => x.Film)
                .WithMany(y => y.FilmActors)
                .HasForeignKey(y => y.ActorId);

            modelBuilder.Entity<FilmActor>()
                .HasOne(x => x.Actor)
                .WithMany(y => y.FilmActors)
                .HasForeignKey(y => y.FilmId);
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}