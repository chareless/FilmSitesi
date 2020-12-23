using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSitesi.Models
{
    public class Yorum
    {
        [Key]


        public int id { get; set; }

        [Display(Name = "Kullanıcı İsmi")]

        public string icerik { get; set; }

        [ForeignKey("userId")]
        public User User { get; set; }

        [ForeignKey("producId")]
        public Product Product { get; set; }

    }
}
