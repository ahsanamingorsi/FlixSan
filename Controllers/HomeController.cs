using FlixSan.Data;
using FlixSan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics.Eventing.Reader;

namespace FlixSan.Controllers
{
    public class HomeController : Controller
    {
        FlixSanDbContext db;
        public HomeController(FlixSanDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index(string searchquery = "non", string searchcategory = "")
        {
            if (searchquery != "non")
            {
                List<MovieDetails> moviedetails = db.tbl_MoviesDetails.Where(x => x.MovieName.Contains(searchquery)).ToList();
                return View(moviedetails);
            }
            else if (searchcategory != "")
            {
                List<MovieDetails> moviedetails = db.tbl_MoviesDetails.Where(x => x.MovieCategory.Contains(searchcategory)).ToList();
                return View(moviedetails);
            }
            else
            {

                List<MovieDetails> moviedetails = db.tbl_MoviesDetails.ToList();
                return View(moviedetails);
            }
        }

        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MovieDetails moviedetails)
        {
            if (!ModelState.IsValid)
            {
                db.tbl_MoviesDetails.Add(moviedetails);
                db.SaveChanges();
                return RedirectToAction("AddMovie");
            }
            return View();
        }


        public IActionResult Admin()
        {
            List<MovieDetails> moviedetails = db.tbl_MoviesDetails.ToList();
            return View(moviedetails);
        }

        public IActionResult EditMovie(int Id)
        {
            var MovieToEdit = db.tbl_MoviesDetails.Find(Id);
            
            return View(MovieToEdit);
        }

        [HttpPost]
        public IActionResult EditMovie(MovieDetails Updatemovie)
        {
            db.tbl_MoviesDetails.Update(Updatemovie);
            db.SaveChanges();

            return RedirectToAction("Admin");
        }
        public IActionResult DeleteMovie(int Id)
        {
            MovieDetails MovieToDelete = db.tbl_MoviesDetails.Find(Id);
            db.tbl_MoviesDetails.Remove(MovieToDelete);
            db.SaveChanges();
            return RedirectToAction("Admin");
        }

        public IActionResult Reset()
        {
            return RedirectToAction("Index");
        }
    }
}
