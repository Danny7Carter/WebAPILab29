using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPILab29.Models;
using System.Web.Http.Results;

namespace WebAPILab29.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        public List<MovieList> GetMovieList()
        {
            MovieEntities db = new MovieEntities();
            List<MovieList> Movies = db.MovieLists.ToList();

            return Movies;
        }
        public List<MovieList> GetMovieByGenre(string genre)
        {
            MovieEntities db = new MovieEntities();
            List<MovieList> MovieGenre = (from m in db.MovieLists
                                        where m.Genre.Contains(genre)
                                        select m).ToList();
            
            return MovieGenre;
        }

        public List<MovieList> GetMovieByLeadActor(string actor)
        {
            MovieEntities db = new MovieEntities();
            List<MovieList> LeadActor = (from m in db.MovieLists
                                         where m.LeadActor.Contains(actor)
                                         select m).ToList();
            return LeadActor;
        }

        public MovieList GetRandomMovie()
        {
            Random rndm = new Random();
            MovieEntities db = new MovieEntities();
            List<MovieList> RandomPick = db.MovieLists.ToList();
            
            int MovieList = RandomPick.Count() + 1;
            int RandomPicks = rndm.Next(0, MovieList);
            MovieList ml = RandomPick[RandomPicks];

            return ml;
        }

        public List<MovieList> GetRandomGenre(string rndgenre)
        {
            Random rndm = new Random();
            MovieEntities db = new MovieEntities();
            List<MovieList> MovieGenreRndm = (from m in db.MovieLists
                                              where m.Genre.Contains(rndgenre)
                                              select m).ToList();
            int MovieList = MovieGenreRndm.Count() + 1;
            int RandomPicks = rndm.Next(0, MovieList);

            return MovieGenreRndm;

        }

    }
}
