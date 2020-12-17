using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSitesi.Models
{
    public class Product
    {
        [Key]

        
        public int id { get; set; }

        [Display(Name = "Ürün İsmi")]
        public int isim { get; set; }

        [Display(Name = "Ürün Açıklaması")]
        public int hakkında { get; set; }

        [Display(Name = "Kategori")]
        public int kategori { get; set; }


        [Display(Name = "Ürünün Yapımcısı")]
        public int yapımcı { get; set; }


        [Display(Name = "Ürün Tarihi")]
        public int tarihi { get; set; }


        [Display(Name = "Ürünün Türü")]
        public int tur { get; set; }

        [Display(Name = "Ürünün Skoru")]
        public int skor { get; set; }


        [Display(Name = "Toplam Süre")]
        public int süre { get; set; }


        

    }
}
