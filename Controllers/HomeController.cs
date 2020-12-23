using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FilmSitesi.Models;

namespace FilmSitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly VeriContext _context;

        public HomeController(VeriContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Filmler(string sortOrder)
        {
            if(sortOrder=="sort")
            {
                var movies = from Movies in _context.movie orderby Movies.Product.isim select Movies;
                var Class = new AllData();
                Class.Movies = movies.ToList();
                return View(Class);
            }
            
            return View();
        }

        public IActionResult Diziler(string sortOrder)
        {
            if (sortOrder =="sort")
            {
                var series= from Series in _context.serie orderby Series.Product.isim select Series;
                var Class = new AllData();
                Class.Series = series.ToList();
                return View(Class);
            }

            return View();
        }

        public IActionResult Animeler(string sortOrder)
        {
            if (sortOrder =="sort")
            {
                var animes = from Anime in _context.anime orderby Anime.Product.isim select Anime;
                var Class = new AllData();
                Class.Anime = animes.ToList();
                return View(Class);
            }

            return View();
        }

        public IActionResult Icerik(string text)
        {
            var product = from Product in _context.product where Product.idName == text select Product;
            var yorum = from Yorum in _context.yorum where Yorum.Product.idName == text  select Yorum;
            var Class = new AllData();
            Class.Product = product.ToList();
            Class.Yorum = yorum.ToList();
            return View(Class);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
