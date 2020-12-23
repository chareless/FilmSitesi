using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSitesi.Models
{
    public class User
    {
        [Key]

        
        public int id { get; set; }

        [Display(Name = "Kullanıcı İsmi")]
        public string kadi { get; set; }

        [Display(Name = "Şifre")]
        public string sifre { get; set; }

        [Display(Name = "Rol")]
        public string rol { get; set; }

        [Display(Name ="İsim")]
        public string isim { get; set; }

        [Display(Name = "Doğum Tarihi")]
        public string dogumTarihi { get; set; }

        [Display(Name = "Cinsiyet")]
        public string cinsiyet { get; set; }

        [Display(Name = "Mail Adresi")]
        public string email { get; set; }

        ICollection<Yorum> yorumlar { get; set; }
    }
}
