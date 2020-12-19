using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSitesi.Models
{
    
        public class AllData 
        { 
           public List<Anime> Anime { get; set; }
           public List<Movies> Movies { get; set; }
           public List<Series> Series { get; set; }
           public List<Product> Product { get; set; }
           public List<User> Users { get; set; }
           public List<Yorum> Yorum { get; set; }
           public List<Slider> Slider { get; set; }
            
    }
    

}
