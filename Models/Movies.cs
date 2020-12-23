using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSitesi.Models
{
    public class Movies
    {

        [Key]

        public int id { get; set; }

        [ForeignKey("productId")]
        public Product Product { get; set; }

    }
}
