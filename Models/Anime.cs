using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSitesi.Models
{
    public class Anime
    {
        [Key]

        public int id { get; set; }
        public Product Product { get; set; }
    }
}
