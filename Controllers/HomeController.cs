using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FilmSitesi.Models;
using Microsoft.EntityFrameworkCore;

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
            var slider = _context.Slider.ToList();
            var movies = (from Movies in _context.movie orderby Movies.id descending select Movies).Take(6);
            var series = (from Series in _context.serie orderby Series.id descending select Series).Take(6);
            var animes = (from Anime in _context.anime orderby Anime.id descending select Anime).Take(6);
            var product = from Product in _context.product orderby Product.skor descending select Product;
            var yorum = _context.yorum.ToList();
            var Class = new AllData();
            Class.Slider=slider;
            Class.Movies = movies.ToList();
            Class.Series = series.ToList();
            Class.Anime = animes.ToList();
            Class.Product = product.ToList();
            Class.Yorum = yorum;
            return View(Class);
        }

        public IActionResult Filmler()
        {
            var movies = from Movies in _context.movie orderby Movies.Product.isim  select Movies;
            var product = from Product in _context.product orderby Product.skor descending select Product;
            var yorum = _context.yorum.ToList();
            var Class = new AllData();
            Class.Movies = movies.ToList();
            Class.Product = product.ToList();
            Class.Yorum = yorum;
            return View(Class);
            
        }
        public IActionResult Diziler()
        {
            var series = from Series in _context.serie orderby Series.Product.isim select Series;
            var product = from Product in _context.product orderby Product.skor descending select Product;
            var yorum = _context.yorum.ToList();
            var Class = new AllData();
            Class.Series = series.ToList();
            Class.Product = product.ToList();
            Class.Yorum = yorum;
            return View(Class);
        }

        public IActionResult Animeler()
        {
            var anime = from Anime in _context.anime orderby Anime.Product.isim select Anime;
            var product = from Product in _context.product orderby Product.skor descending select Product;
            var yorum = _context.yorum.ToList();
            var Class = new AllData();
            Class.Anime = anime.ToList();
            Class.Product = product.ToList();
            Class.Yorum = yorum;
            return View(Class);
        }

        public IActionResult Icerik(string text)
        {
            var product = from Product in _context.product where Product.idName == text select Product;
            var yorum = from Yorum in _context.yorum where Yorum.Product.idName == text  select Yorum;
            var user = _context.user.ToList();
            var Class = new AllData();
            Class.Product = product.ToList();
            Class.Yorum = yorum.ToList();
            Class.User = user;
            return View(Class);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Icerik([Bind("id,icerik,userId,productId")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yorum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yorum);
        }

        public IActionResult Iletisim()
        {
            return View();
        }

        public async Task<IActionResult> YorumDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.yorum
                .Include(y => y.Product)
                .Include(y => y.User)
                .FirstOrDefaultAsync(m => m.id == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        [HttpPost, ActionName("YorumDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YorumDeleteConfirmed(int id)
        {
            var yorum = await _context.yorum.FindAsync(id);
            _context.yorum.Remove(yorum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
