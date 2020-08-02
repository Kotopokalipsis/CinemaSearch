using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using SharedKernel.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public interface IFilmRepository: IRepository<Film>
    {
        public Task<List<Film>> GetFilmByFilmTitle(string title);
        
        public Task<List<Film>> GetFilmByActorName(string actorName);
        
        public Task<List<Film>> GetFilmByGenreTitle(string genreTitle);
    }
}