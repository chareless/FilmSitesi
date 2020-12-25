using FilmSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSitesi.Controllers
{
    public class OylananlarController : Controller
    {
        private readonly VeriContext _context;

        public OylananlarController(VeriContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var product = from Product in _context.product orderby Product.skor descending select Product;
            var Class = new AllData();
            Class.Product = product.ToList();
            return View(Class);
        }
    }
}
