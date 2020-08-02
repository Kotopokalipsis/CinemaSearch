using System;
using System.Collections.Generic;
using System.Data.Common;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Tests.Data
{
    public class SharedDatabaseFixture : IDisposable
    {
        private static readonly object _lock = new object(); 
        private static bool _databaseInitialized; 
    
        public SharedDatabaseFixture()
        {
            Connection = new SqlConnection(@"Server=localhost;Database=cinemasearch_test;Trusted_Connection=True;");
        
            Seed();
        
            Connection.Open();
        }

        public DbConnection Connection { get; }
    
        public DbContext CreateContext(DbTransaction transaction = null)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Connection).Options;
            var dbContext = new ApplicationDbContext(options);
            
            if (transaction != null)
            {
                dbContext.Database.UseTransaction(transaction);
            }
        
            return dbContext;
        }
    
        private void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        var genreAction = FilmFixture.GetSecondGenre();
                        
                        var firstFilm = FilmFixture.GetFirstFilm();
                        
                        var secondFilm = FilmFixture.GetSecondFilm();
                        secondFilm.Genere = genreAction;
                        
                        var thirdFilm = FilmFixture.GetThirdFilm();
                        thirdFilm.Genere = genreAction;
                        
                        context.Set<Film>().Add(firstFilm);
                        context.Set<Film>().Add(secondFilm);
                        context.Set<Film>().Add(thirdFilm);
                        
                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public void Dispose() => Connection.Dispose();
    }
}