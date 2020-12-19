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
        public string isim { get; set; }

        [Display(Name = "Ürün Açıklaması")]
        public string hakkında { get; set; }

        [Display(Name = "Kategori")]
        public string kategori { get; set; }


        [Display(Name = "Ürünün Yapımcısı")]
        public string yapımcı { get; set; }


        [Display(Name = "Ürün Tarihi")]
        public string tarihi { get; set; }


        [Display(Name = "Ürünün Türü")]
        public string tur { get; set; }

        [Display(Name = "Ürünün Skoru")]
        public int skor { get; set; }


        [Display(Name = "Toplam Süre")]
        public string süre { get; set; }


        [Display(Name ="Ürün Fotoğraf Url")]
        public string url { get; set; }


        

    }
}
