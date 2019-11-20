using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Models;
using Movies.ViewModels;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Star Wars: The Empire Strikes Back!", Id = 23241342 };

            var customers = new List<Customer>{
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);




            //return something();
            //return whatever();
            // new emptyresult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name"});

        }

        public ActionResult Edit(int id)
        {
            return Content("Id = " + id);
        }



        public ActionResult Index(int? pageIndex, string sortby)
        {
            if (!pageIndex.HasValue)
                pageIndex = 2;

            if (String.IsNullOrWhiteSpace(sortby))
                sortby = "Name";

            return Content(String.Format("pageIndex ={0}&sortBy ={1}", pageIndex, sortby));


        }

        [Route("Movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]

        public ActionResult ByReleaseYear(int year, int? month)
        {
            return Content(year + " / " + month);
        }
    }
}
// localhost:23434/Movies/Random