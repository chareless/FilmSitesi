using FilmSitesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSitesi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly VeriContext _context;

        public AdminController(VeriContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Product()
        {
            return View(await _context.product.ToListAsync());
        }

        public async Task<IActionResult> ProductDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.product
                .FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        public IActionResult ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate([Bind("id,idName,isim,hakkinda,kategori,yapimci,tarihi,tur,skor,sure,url,sliderUrl,yanUrl,detailUrl,fragman")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Product));
            }
            return View(product);
        }
        public async Task<IActionResult> ProductEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(int id, [Bind("id,idName,isim,hakkinda,kategori,yapimci,tarihi,tur,skor,sure,url,sliderUrl,yanUrl,detailUrl,fragman")] Product product)
        {
            if (id != product.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Product));
            }
            return View(product);
        }
        public async Task<IActionResult> ProductDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.product
                .FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("ProductDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDeleteConfirmed(int id)
        {
            var product = await _context.product.FindAsync(id);
            _context.product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Product));
        }

        private bool ProductExists(int id)
        {
            return _context.product.Any(e => e.id == id);
        }



        //ANİME BİLGİLERİ



        public async Task<IActionResult> Anime()
        {
            var veriContext = _context.anime.Include(a => a.Product);
            return View(await veriContext.ToListAsync());
        }

        public IActionResult AnimeCreate()
        {
            ViewData["productId"] = new SelectList(_context.product, "id", "id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AnimeCreate([Bind("id,productId")] Anime anime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Anime));
            }
            ViewData["productId"] = new SelectList(_context.product, "id", "id", anime.productId);
            return View(anime);
        }

        public async Task<IActionResult> AnimeEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _context.anime.FindAsync(id);
            if (anime == null)
            {
                return NotFound();
            }
            ViewData["productId"] = new SelectList(_context.product, "id", "id", anime.productId);
            return View(anime);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AnimeEdit(int id, [Bind("id,productId")] Anime anime)
        {
            if (id != anime.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimeExists(anime.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Anime));
            }
            ViewData["productId"] = new SelectList(_context.product, "id", "id", anime.productId);
            return View(anime);
        }

        public async Task<IActionResult> AnimeDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _context.anime
                .Include(a => a.Product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        [HttpPost, ActionName("AnimeDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AnimeDeleteConfirmed(int id)
        {
            var anime = await _context.anime.FindAsync(id);
            _context.anime.Remove(anime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Anime));
        }

        private bool AnimeExists(int id)
        {
            return _context.anime.Any(e => e.id == id);
        }



        //MOVİE BİLGİLERİ



        public async Task<IActionResult> Movies()
        {
            var veriContext = _context.movie.Include(m => m.Product);
            return View(await veriContext.ToListAsync());
        }



        public IActionResult MoviesCreate()
        {
            ViewData["productId"] = new SelectList(_context.product, "id", "id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MoviesCreate([Bind("id,productId")] Movies movies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Movies));
            }
            ViewData["productId"] = new SelectList(_context.product, "id", "id", movies.productId);
            return View(movies);
        }

        public async Task<IActionResult> MoviesEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.movie.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }
            ViewData["productId"] = new SelectList(_context.product, "id", "id", movies.productId);
            return View(movies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MoviesEdit(int id, [Bind("id,productId")] Movies movies)
        {
            if (id != movies.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesExists(movies.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Movies));
            }
            ViewData["productId"] = new SelectList(_context.product, "id", "id", movies.productId);
            return View(movies);
        }

        public async Task<IActionResult> MoviesDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.movie
                .Include(m => m.Product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        [HttpPost, ActionName("MoviesDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MoviesDeleteConfirmed(int id)
        {
            var movies = await _context.movie.FindAsync(id);
            _context.movie.Remove(movies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Movies));
        }

        private bool MoviesExists(int id)
        {
            return _context.movie.Any(e => e.id == id);
        }



        //SERİES BİLGİLERİ



        public async Task<IActionResult> Series()
        {
            var veriContext = _context.serie.Include(s => s.Product);
            return View(await veriContext.ToListAsync());
        }

        public IActionResult SeriesCreate()
        {
            ViewData["productId"] = new SelectList(_context.product, "id", "id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SeriesCreate([Bind("id,productId")] Series series)
        {
            if (ModelState.IsValid)
            {
                _context.Add(series);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Series));
            }
            ViewData["productId"] = new SelectList(_context.product, "id", "id", series.productId);
            return View(series);
        }

        public async Task<IActionResult> SeriesEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var series = await _context.serie.FindAsync(id);
            if (series == null)
            {
                return NotFound();
            }
            ViewData["productId"] = new SelectList(_context.product, "id", "id", series.productId);
            return View(series);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SeriesEdit(int id, [Bind("id,productId")] Series series)
        {
            if (id != series.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(series);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeriesExists(series.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Series));
            }
            ViewData["productId"] = new SelectList(_context.product, "id", "id", series.productId);
            return View(series);
        }

        public async Task<IActionResult> SeriesDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var series = await _context.serie
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (series == null)
            {
                return NotFound();
            }

            return View(series);
        }

        [HttpPost, ActionName("SeriesDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SeriesDeleteConfirmed(int id)
        {
            var series = await _context.serie.FindAsync(id);
            _context.serie.Remove(series);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Series));
        }

        private bool SeriesExists(int id)
        {
            return _context.serie.Any(e => e.id == id);
        }



        //SLİDER BİLGİLERİ



        public async Task<IActionResult> Slider()
        {
            var veriContext = _context.Slider.Include(s => s.Product);
            return View(await veriContext.ToListAsync());
        }

        public async Task<IActionResult> SliderDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Slider
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        public IActionResult SliderCreate()
        {
            ViewData["productId"] = new SelectList(_context.product, "id", "id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SliderCreate([Bind("id,productId")] Slider slider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Slider));
            }
            ViewData["productId"] = new SelectList(_context.product, "id", "id", slider.productId);
            return View(slider);
        }

        public async Task<IActionResult> SliderEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Slider.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }
            ViewData["productId"] = new SelectList(_context.product, "id", "id", slider.productId);
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SliderEdit(int id, [Bind("id,productId")] Slider slider)
        {
            if (id != slider.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderExists(slider.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Slider));
            }
            ViewData["productId"] = new SelectList(_context.product, "id", "id", slider.productId);
            return View(slider);
        }

        public async Task<IActionResult> SliderDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Slider
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        [HttpPost, ActionName("SliderDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SliderDeleteConfirmed(int id)
        {
            var slider = await _context.Slider.FindAsync(id);
            _context.Slider.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Slider));
        }

        private bool SliderExists(int id)
        {
            return _context.Slider.Any(e => e.id == id);
        }
    }
}