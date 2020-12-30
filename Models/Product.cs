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

        [Display(Name = "ID İsim")]
        public string idName { get; set; }

        [Display(Name = "İsim")]
        public string isim { get; set; }

        [Display(Name = "Hakkında")]
        public string hakkinda { get; set; }

        [Display(Name = "Kategori")]
        public string kategori { get; set; }

        [Display(Name = "Yapımcı")]
        public string yapimci { get; set; }

        [Display(Name = "Tarih")]
        public string tarihi { get; set; }

        [Display(Name = "Tür")]
        public string tur { get; set; }

        [Display(Name = "Skor")]
        public float skor { get; set; }

        [Display(Name = "Süre")]
        public string sure { get; set; }

        [Display(Name ="Fotoğraf")]
        public string url { get; set; }

        [Display(Name = "SliderFotoğraf")]
        public string sliderUrl { get; set; }

        [Display(Name = "YanFotoğraf")]
        public string yanUrl { get; set; }

        [Display(Name = "DetaylarFotoğraf")]
        public string detailUrl { get; set; }

        [Display(Name = "Fragman URL")]
        public string fragman { get; set; }

        public ICollection<Anime> animes { get; set; }
        public ICollection<Movies> movies { get; set; }
        public ICollection<Series> series { get; set; }
        public ICollection<Yorum> yorumlar { get; set; }
        public ICollection<Slider> sliders { get; set; }


    }
}
