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
    public class AdminController : Controller
    {
        private readonly VeriContext _context;

        public AdminController(VeriContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }


        //PRODUCT BİLGİLERİ


        // GET: Products
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Product()
        {
            return View(await _context.product.ToListAsync());
        }
        [Authorize(Roles = "Admin")]
        // GET: Products/Details/5
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
        [Authorize(Roles = "Admin")]
        // GET: Products/Create
        public IActionResult ProductCreate()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate([Bind("id,idName,isim,hakkında,kategori,yapımcı,tarihi,tur,skor,süre,url,sliderUrl,yanUrl,detailUrl,fragman")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        [Authorize(Roles = "Admin")]
        // GET: Products/Edit/5
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
        [Authorize(Roles = "Admin")]
        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(int id, [Bind("id,idName,isim,hakkında,kategori,yapımcı,tarihi,tur,skor,süre,url,sliderUrl,yanUrl,detailUrl,fragman")] Product product)
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
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        [Authorize(Roles = "Admin")]
        // GET: Products/Delete/5
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
        [Authorize(Roles = "Admin")]
        // POST: Products/Delete/5
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



        // GET: Animes
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Anime()
        {
            var veriContext = _context.anime.Include(a => a.Product);
            return View(await veriContext.ToListAsync());
        }

        // GET: Animes/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AnimeDetails(int? id)
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

        // GET: Animes/Create
        [Authorize(Roles = "Admin")]
        public IActionResult AnimeCreate()
        {
            ViewData["productId"] = new SelectList(_context.product, "id", "id");
            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
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

        // GET: Animes/Edit/5
        [Authorize(Roles = "Admin")]
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

        // POST: Animes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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

        // GET: Animes/Delete/5
        [Authorize(Roles = "Admin")]
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

        // POST: Animes/Delete/5
        [Authorize(Roles = "Admin")]
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


        // GET: Movies
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Movies()
        {
            var veriContext = _context.movie.Include(m => m.Product);
            return View(await veriContext.ToListAsync());
        }

        // GET: Movies/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MoviesDetails(int? id)
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

        // GET: Movies/Create
        [Authorize(Roles = "Admin")]
        public IActionResult MoviesCreate()
        {
            ViewData["productId"] = new SelectList(_context.product, "id", "id");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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

        // GET: Movies/Edit/5
        [Authorize(Roles = "Admin")]
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

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
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

        // GET: Movies/Delete/5
        [Authorize(Roles = "Admin")]
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

        // POST: Movies/Delete/5
        [HttpPost, ActionName("MoviesDelete")]
        [Authorize(Roles = "Admin")]
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



        // GET: Series
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Series()
        {
            var veriContext = _context.serie.Include(s => s.Product);
            return View(await veriContext.ToListAsync());
        }

        // GET: Series/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SeriesDetails(int? id)
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

        // GET: Series/Create
        [Authorize(Roles = "Admin")]
        public IActionResult SeriesCreate()
        {
            ViewData["productId"] = new SelectList(_context.product, "id", "id");
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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

        // GET: Series/Edit/5
        [Authorize(Roles = "Admin")]
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

        // POST: Series/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
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

        // GET: Series/Delete/5
        [Authorize(Roles = "Admin")]
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

        // POST: Series/Delete/5
        [HttpPost, ActionName("SeriesDelete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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



        // GET: Sliders
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Slider()
        {
            var veriContext = _context.Slider.Include(s => s.Product);
            return View(await veriContext.ToListAsync());
        }

        // GET: Sliders/Details/5
        [Authorize(Roles = "Admin")]
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

        // GET: Sliders/Create
        [Authorize(Roles = "Admin")]
        public IActionResult SliderCreate()
        {
            ViewData["productId"] = new SelectList(_context.product, "id", "id");
            return View();
        }

        // POST: Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
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

        // GET: Sliders/Edit/5
        [Authorize(Roles = "Admin")]
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

        // POST: Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
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

        // GET: Sliders/Delete/5
        [Authorize(Roles = "Admin")]
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

        // POST: Sliders/Delete/5
        [HttpPost, ActionName("SliderDelete")]
        [Authorize(Roles = "Admin")]
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



        //YORUM BİLGİLERİ


        // GET: Yorums
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Yorum()
        {
            var veriContext = _context.yorum.Include(y => y.Product).Include(y => y.User);
            return View(await veriContext.ToListAsync());
        }

        // GET: Yorums/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> YorumDetails(int? id)
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


        // GET: Yorums/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> YorumEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.yorum.FindAsync(id);
            if (yorum == null)
            {
                return NotFound();
            }
            ViewData["productId"] = new SelectList(_context.product, "id", "id", yorum.productId);
            ViewData["userId"] = new SelectList(_context.user, "Id", "Id", yorum.userId);
            return View(yorum);
        }

        // POST: Yorums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YorumEdit(int id, [Bind("id,icerik,userId,productId")] Yorum yorum)
        {
            if (id != yorum.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yorum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YorumExists(yorum.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Yorum));
            }
            ViewData["productId"] = new SelectList(_context.product, "id", "id", yorum.productId);
            ViewData["userId"] = new SelectList(_context.user, "Id", "Id", yorum.userId);
            return View(yorum);
        }

        // GET: Yorums/Delete/5
        [Authorize(Roles = "Admin")]
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

        // POST: Yorums/Delete/5
        [HttpPost, ActionName("YorumDelete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YorumDeleteConfirmed(int id)
        {
            var yorum = await _context.yorum.FindAsync(id);
            _context.yorum.Remove(yorum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Yorum));
        }

        private bool YorumExists(int id)
        {
            return _context.yorum.Any(e => e.id == id);
        }
    }
}
