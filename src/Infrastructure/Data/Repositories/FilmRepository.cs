using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    /// <summary>
    /// The FilmRepository class
    /// </summary>
    public class FilmRepository: IFilmRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FilmRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Return films whose title contains <paramref name="title"/>
        /// </summary>
        /// <param name="title">The film title</param>
        public Task<List<Film>> GetFilmByFilmTitle(string title)
        {
            return 
                _dbContext.Set<Film>()
                    .Where(film => film.Title.Contains(title))
                    .Include(film => film.Genere)
                    .Include(film => film.FilmActors)
                        .ThenInclude(filmActor => filmActor.Actor)
                    .ToListAsync();
        }
        
        /// <summary>
        /// Return films whose actors name contains <paramref name="actorName"/>
        /// </summary>
        /// <param name="actorName">The actor name</param>
        public Task<List<Film>> GetFilmByActorName(string actorName)
        {
            var actorId = _dbContext
                                    .Set<Actor>()
                                    .Where(actor => actor.Name.Contains(actorName))
                                    .Select(actor => actor.Id)
                                    .FirstOrDefault();
            
            if (actorId == 0) return Task.FromResult(new List<Film>());
            
            return 
                _dbContext.Set<FilmActor>()
                    .Include(filmActor => filmActor.Film)
                        .ThenInclude(film => film.Genere)
                    .Include(filmActor => filmActor.Film)
                        .ThenInclude(film => film.FilmActors)
                            .ThenInclude(filmActors => filmActors.Actor)
                    .Where(filmActor => filmActor.Actor.Id == actorId)
                    .Select(filmActor => filmActor.Film)
                    .ToListAsync();
        }
        
        /// <summary>
        /// Return films whose genre title contains <paramref name="genreTitle"/>
        /// </summary>
        /// <param name="genreTitle">The genre title</param>
        public Task<List<Film>> GetFilmByGenreTitle(string genreTitle)
        {
            return
                _dbContext.Set<Film>()
                    .Include(film => film.FilmActors)
                        .ThenInclude(filmActors => filmActors.Actor)
                    .Include(film => film.Genere)
                    .Where(film => film.Genere.Title.Contains(genreTitle))
                    .ToListAsync();
        }

        /// <summary>
        /// Return all films
        /// </summary>
        public Task<List<Film>> GetListAsync()
        {
            return 
                _dbContext.Set<Film>()
                    .Include(film => film.Genere)
                    .Include(film => film.FilmActors)
                        .ThenInclude(filmActor => filmActor.Actor)
                    .ToListAsync();
        }
    }
}