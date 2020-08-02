using System;
using System.Collections.Generic;
using Core.Entities;

namespace Tests.Data
{
    public static class FilmFixture
    {
        public static readonly List<string> QueriesForFilmTitle = new List<string>(){"Back", "the", "Action", "Equali"};
        public static readonly List<string> QueriesForActorName = new List<string>(){"Washi", "Mich", "Action", "Back"};
        public static readonly List<string> QueriesForGenreTitle = new List<string>(){"Action", "the", "Specul", "fiction"};
        
        public static Genre GetFirstGenre()
        {
            var genre = new Genre();
            genre.Title = "Speculative fiction";

            return genre;
        }
        
        public static Genre GetSecondGenre()
        {
            var genre = new Genre();
            genre.Title = "Action";

            return genre;
        }
        
        public static Actor GetFirstActor()
        {
            var actor = new Actor();
            actor.Name = "Michael Andrew Fox";

            return actor;
        }
        
        public static Actor GetSecondActor()
        {
            var actor = new Actor();
            actor.Name = "Denzel Washington";

            return actor;
        }
        
        public static Actor GetThirdActor()
        {
            var actor = new Actor();
            actor.Name = "Marton Csokas";

            return actor;
        }

        public static Film GetFirstFilm()
        {
            var film = new Film();
            film.Title = "Back to the future";
            film.Description = "Back to the Future is a 1985 American science fiction film directed by Robert " +
                               "Zemeckis and written by Zemeckis and Bob Gale.";
            film.DateOfCreation = new DateTime(1985, 10, 12);
            film.Genere = GetFirstGenre();
            
            film.FilmActors = new List<FilmActor>();
            film.FilmActors.Add(GetFirstFilmActor(GetFirstActor(), film));

            return film;
        }
        
        public static Film GetSecondFilm()
        {
            var film = new Film();
            film.Title = "The Equalizer";
            film.Description = "A man believes he has put his mysterious past behind him and has dedicated himself to beginning a new, " +
                               "quiet life, before he meets a young girl under the control of ultra-violent Russian gangsters " +
                               "and can't stand idly by.";
            film.DateOfCreation = new DateTime(1999, 10, 12);
            film.Genere = GetSecondGenre();
            
            film.FilmActors = new List<FilmActor>();
            film.FilmActors.Add(GetSecondFilmActor(GetSecondActor(), film));

            return film;
        }
        
        public static Film GetThirdFilm()
        {
            var film = new Film();
            film.Title = "Mad Max: Fury Road";
            film.Description = "In a post-apocalyptic wasteland, a woman rebels against a tyrannical " +
                                "ruler in search for her homeland with the aid of a group of female prisoners," +
                                " a psychotic worshiper, and a drifter named Max.";
            film.DateOfCreation = new DateTime(2015, 10, 12);
            film.Genere = GetSecondGenre();

            film.FilmActors = new List<FilmActor>();
            film.FilmActors.Add(GetThirdFilmActor(GetThirdActor(), film));
            
            return film;
        }

        public static FilmActor GetFirstFilmActor(Actor actor, Film film)
        {
            var filmActor = new FilmActor();
            filmActor.Actor = actor;
            filmActor.Film = film;

            return filmActor;
        }
        
        public static FilmActor GetSecondFilmActor(Actor actor, Film film)
        {
            var filmActor = new FilmActor();
            filmActor.Actor = actor;
            filmActor.Film = film;

            return filmActor;
        }
        
        public static FilmActor GetThirdFilmActor(Actor actor, Film film)
        {
            var filmActor = new FilmActor();
            filmActor.Actor = actor;
            filmActor.Film = film;

            return filmActor;
        }

        public static List<Film> GetAllFilms()
        {
            var films = new List<Film>();
            
            films.Add(GetFirstFilm());
            films.Add(GetSecondFilm());
            films.Add(GetThirdFilm());

            return films;
        }
        
        public static List<Film> GetFilmsByQueriesForFilmTitle(string query)
        {
            switch (query)
            {
                case "Back":
                {
                    var film = new List<Film>();
                    film.Add(GetFirstFilm());

                    return film;
                }
                
                case "the":
                {
                    var film = new List<Film>();
                    film.Add(GetFirstFilm());
                    film.Add(GetSecondFilm());

                    return film;
                }
                
                case "Action":
                {
                    var film = new List<Film>();
                    
                    return film;
                }
                
                case "Equali":
                {
                    var film = new List<Film>();
                    film.Add(GetSecondFilm());
                    
                    return film;
                }
            }

            throw new ArgumentException($"Query is undefined {query}");
        }
        
        public static List<Film> GetFilmsByQueriesForActorName(string query)
        {
            switch (query)
            {
                case "Washi":
                {
                    var film = new List<Film>();
                    film.Add(GetSecondFilm());

                    return film;
                }
                
                case "Mich":
                {
                    var film = new List<Film>();
                    film.Add(GetFirstFilm());

                    return film;
                }
                
                case "Action":
                {
                    var film = new List<Film>();
                    
                    return film;
                }
                
                case "Back":
                {
                    var film = new List<Film>();

                    return film;
                }
            }

            throw new ArgumentException($"Query is undefined {query}");
        }
        
        public static List<Film> GetFilmsByQueriesForGenreTitle(string query)
        {
            switch (query)
            {
                case "Action":
                {
                    var film = new List<Film>();
                    film.Add(GetSecondFilm());
                    film.Add(GetThirdFilm());

                    return film;
                }
                
                case "the":
                {
                    var film = new List<Film>();

                    return film;
                }
                
                case "Specul":
                {
                    var film = new List<Film>();
                    film.Add(GetFirstFilm());
                    
                    return film;
                }
                
                case "fiction":
                {
                    var film = new List<Film>();
                    film.Add(GetFirstFilm());
                    
                    return film;
                }
            }

            throw new ArgumentException($"Query is undefined {query}");
        }

        public static int GetActorIdByQueriesForActorName(string query)
        {
            switch (query)
            {
                case "Washi":
                {
                    return 3;
                }
                
                case "Mich":
                {
                    return 1;
                }
                
                case "Action":
                {
                    return 0;
                }
                
                case "Back":
                {
                    return 0;
                }
            }

            throw new ArgumentException("Query is undefined");
        }
    }
}