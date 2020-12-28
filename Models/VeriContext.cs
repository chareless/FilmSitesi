using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FilmSitesi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FilmSitesi.Models
{
    
        public class VeriContext : IdentityDbContext<User>
        {
            public VeriContext(DbContextOptions<VeriContext> options) : base(options)
            {

            }
            public DbSet<Product> product { get; set; }
            public DbSet<User> user { get; set; }
            public DbSet<Yorum> yorum { get; set; }
            public DbSet<Anime> anime { get; set; }
            public DbSet<Movies> movie{ get; set; }
            public DbSet<Series> serie { get; set; }
            public DbSet<Slider> Slider { get; set; }
        }
    
}
