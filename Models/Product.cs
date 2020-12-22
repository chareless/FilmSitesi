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

        [Display(Name = "İsim")]
        public string isim { get; set; }

        [Display(Name = "Hakkında")]
        public string hakkında { get; set; }

        [Display(Name = "Kategori")]
        public string kategori { get; set; }


        [Display(Name = "Yapımcı")]
        public string yapımcı { get; set; }


        [Display(Name = "Tarih")]
        public string tarihi { get; set; }


        [Display(Name = "Tür")]
        public string tur { get; set; }

        [Display(Name = "Skor")]
        public int skor { get; set; }


        [Display(Name = "Süre")]
        public string süre { get; set; }


        [Display(Name ="Fotoğraf")]
        public string url { get; set; }


        

    }
}
