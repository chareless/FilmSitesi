using FilmSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSitesi.Controllers
{
    public class EklenenlerController : Controller
    {
        private readonly VeriContext _context;

        public EklenenlerController(VeriContext context)
        {
            _context = context;
        }

        public IActionResult Anime()
        {
            var anime = from Anime in _context.anime orderby Anime.id descending select Anime;
            var product = _context.product.ToList();
            var Class = new AllData();
            Class.Anime = anime.ToList();
            Class.Product = product;
            return View(Class);
        }
        public IActionResult Film()
        {
            var movies = from Movies in _context.movie orderby Movies.id descending select Movies;
            var product = _context.product.ToList();
            var Class = new AllData();
            Class.Movies = movies.ToList();
            Class.Product = product;
            return View(Class);
        }
        public IActionResult Dizi()
        {
            var series = from Series in _context.serie orderby Series.id descending select Series;
            var product = _context.product.ToList();
            var Class = new AllData();
            Class.Series = series.ToList();
            Class.Product = product;
            return View(Class);
        }
    }
}
