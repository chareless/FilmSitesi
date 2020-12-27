using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSitesi.Models
{
    public class User:IdentityUser
    {

        [Display(Name ="İsim")]
        public string isim { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime dogumTarihi { get; set; }

        [Display(Name = "Cinsiyet")]
        public string cinsiyet { get; set; }

        ICollection<Yorum> yorumlar { get; set; }
    }
}
