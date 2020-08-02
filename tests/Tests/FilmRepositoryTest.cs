using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Tests.Data;
using Xunit;

namespace Tests
{
    public class FilmRepositoryTest : IClassFixture<SharedDatabaseFixture>
    {
        public SharedDatabaseFixture Fixture { get; }

        public FilmRepositoryTest(SharedDatabaseFixture fixture)
        {
            Fixture = fixture;
        } 
        
        [Fact]
        public void GetListAsyncTest()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    var filmListTask = context
                                            .Set<Film>()
                                            .Include(film => film.Genere)
                                            .Include(film => film.FilmActors)
                                                .ThenInclude(filmActor => filmActor.Actor)
                                            .ToListAsync();
                    
                    var filmListResult = filmListTask.Result;
                    
                    var expectedFilmList = FilmFixture.GetAllFilms();
                    
                    AssertData(expectedFilmList, filmListResult);
                }
            }
        }

        [Fact]
        public void GetFilmByFilmTitleTest()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    foreach (var query in FilmFixture.QueriesForFilmTitle)
                    {
                        var filmListTask = context
                                                .Set<Film>()
                                                .Where(film => film.Title.Contains(query))
                                                .Include(film => film.Genere)
                                                .Include(film => film.FilmActors)
                                                    .ThenInclude(filmActor => filmActor.Actor)
                                                .ToListAsync();
                    
                        var filmListResult = filmListTask.Result;
                    
                        var expectedFilmList = FilmFixture.GetFilmsByQueriesForFilmTitle(query);

                        AssertData(expectedFilmList, filmListResult);
                    }

                }
            }
        }
        
        [Fact]
        public void GetFilmByActorNameTest()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    foreach (var query in FilmFixture.QueriesForActorName)
                    {
                        var actorId = context
                                                .Set<Actor>()
                                                .Where(actor => actor.Name.Contains(query))
                                                .Select(actor => actor.Id)
                                                .FirstOrDefault();

                        var filmListTask = context
                                                .Set<FilmActor>()
                                                .Include(filmActor => filmActor.Film)
                                                    .ThenInclude(film => film.Genere)
                                                .Include(filmActor => filmActor.Film)
                                                    .ThenInclude(film => film.FilmActors)
                                                        .ThenInclude(filmActors => filmActors.Actor)
                                                .Where(filmActor => filmActor.Actor.Id == actorId)
                                                .Select(filmActor => filmActor.Film)
                                                .ToListAsync();
                    
                        var filmListResult = filmListTask.Result;
                    
                        var expectedFilmList = FilmFixture.GetFilmsByQueriesForActorName(query);

                        AssertData(expectedFilmList, filmListResult);
                    }

                }
            }
        }

        [Fact]
        public void GetFilmByGenreTitleTest()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    foreach (var query in FilmFixture.QueriesForGenreTitle)
                    {
                        var filmListTask = context
                                                .Set<Film>()
                                                .Include(film => film.FilmActors)
                                                    .ThenInclude(filmActors => filmActors.Actor)
                                                .Include(film => film.Genere)
                                                .Where(film => film.Genere.Title.Contains(query))
                                                .ToListAsync();

                        var filmListResult = filmListTask.Result;
                    
                        var expectedFilmList = FilmFixture.GetFilmsByQueriesForGenreTitle(query);

                        AssertData(expectedFilmList, filmListResult);
                    }

                }
            }
        }
        
        private void AssertData(List<Film> expected, List<Film> actual)
        {
            if (expected.Count == 0) Assert.Empty(actual);
            else if (expected.Count == actual.Count)
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    var expectedFilm = expected[i];
                    var filmResult = actual[i];

                    Assert.Equal(expectedFilm.Title, filmResult.Title);
                    Assert.Equal(expectedFilm.Description, filmResult.Description);
                    Assert.Equal(expectedFilm.DateOfCreation, filmResult.DateOfCreation);
                    Assert.Equal(expectedFilm.Genere.Title, filmResult.Genere.Title);

                    for (int j = 0; j < expectedFilm.FilmActors.Count; j++)
                    {
                        var expectedFilmActor = expectedFilm.FilmActors[j];
                        var filmActorResult = filmResult.FilmActors[j];

                        Assert.Equal(expectedFilmActor.Actor.Name, filmActorResult.Actor.Name);
                        Assert.Equal(expectedFilmActor.Film.Title, filmActorResult.Film.Title);
                    }
                }
            }
            else Assert.True(false, "ExpectedList.count not equal ActualList.count");
        }
    }
}