using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

using Vidly.Migrations;



namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;


        //ctor key 
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ViewResult Index()
        {
            //var movies = GetMovies();
            var movies = _context.Movies.Include(g => g.Genre).ToList();

            return View(movies); 
        }


        //http://localhost:65383/Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Tanapat" };
            //return View(movie);
            //return HttpNotFound();
            //return new EmptyResult(); 
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };
            return View(customers);
            /*
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            */
        }


        //[Route("movies/released/{year:regex(^\\d{4}$)}/{month:regex(^\\d{2}$):range(1, 12)}")]
        //http://localhost:65383/movies/released/2016/01 
        public ActionResult ByReleaseDate(int year, int month)
        {
            //return View();
            return Content(year + "/" + month);
        }


        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }

        

        public ViewResult New()
        {
            var genres = _context.Genres.ToList(); //get form databas Geners 
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("NewMovies", viewModel);
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()//get form database 
            };
            return View("NewMovies", viewModel);
        }


       
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            
            if(movie.Id == 0 )
            {
                _context.Movies.Add(movie);
            }

            try
            {
                
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberStock = movie.NumberStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;

                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            
           
            //_context.SaveChanges();
            return RedirectToAction("Index", "Movies");
            
        }
       
        
            /*
            try
            {
                var movidDB = _context.Movies.Single(c => c.Id == movie.Id);
                movidDB.Name = movie.Name;
                movidDB.ReleaseDate = movie.ReleaseDate;
                movidDB.GenreId = movie.GenreId;
                movidDB.NumberStock = movidDB.NumberStock;

                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Movies");
            */


        /*
        private IEnumerable<Movie> GetMovies()
        {

            
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
            
        }*/
    }
}