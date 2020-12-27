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

        [Display(Name = "İçerik")]

        public string icerik { get; set; }
        
        [Display(Name = "UserId")]
        public string userId { get; set; }

        [Display(Name = "ProductId")]
        public int productId { get; set; }

        [ForeignKey("userId")]
        public User User { get; set; }

        [ForeignKey("productId")]
        public Product Product { get; set; }

    }
}
