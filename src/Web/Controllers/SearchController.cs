using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Web.Resources;

namespace Web.Controllers
{
    /// <summary>
    /// The SearchController class.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController: Controller
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public SearchController(IFilmRepository filmRepository, ApplicationDbContext dbContext, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Get all films and mapped these on FilmResource
        /// </summary>
        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> GetAllFilms()
        {
            var films = await _filmRepository.GetListAsync();
            
            var mappedFilmResources = _mapper.Map<List<Film>, List<FilmResource>>(films);
            
            return Json(mappedFilmResources);
        }
        
        /// <summary>
        /// Get films whose title contains <paramref name="query"/> and mapped these on FilmResource
        /// </summary>
        /// <param name="query">This is search query</param>
        [Route("title")]
        [HttpGet]
        public async Task<IActionResult> SearchFilmByTitle([FromQuery] string query)
        {
            var films = await _filmRepository.GetFilmByFilmTitle(query);
            
            var mappedFilmResources = _mapper.Map<List<Film>, List<FilmResource>>(films);
            
            return Json(mappedFilmResources);
        }
        
        /// <summary>
        /// Get films whose actors name contains <paramref name="query"/> and mapped these on FilmResource
        /// </summary>
        /// <param name="query">This is search query</param>
        [Route("actor")]
        [HttpGet]
        public async Task<IActionResult> SearchFilmByActor([FromQuery] string query)
        {
            var films = await _filmRepository.GetFilmByActorName(query);
            
            var mappedFilmResources = _mapper.Map<List<Film>, List<FilmResource>>(films);
            
            return Json(mappedFilmResources);
        }
        
        /// <summary>
        /// Get films whose genre title contains <paramref name="query"/> and mapped these on FilmResource
        /// </summary>
        /// <param name="query">This is search query</param>
        [Route("genre")]
        [HttpGet]
        public async Task<IActionResult> SearchFilmByGenre([FromQuery] string query)
        {
            var films = await _filmRepository.GetFilmByGenreTitle(query);
            
            var mappedFilmResources = _mapper.Map<List<Film>, List<FilmResource>>(films);
            
            return Json(mappedFilmResources);
        }
    }
}