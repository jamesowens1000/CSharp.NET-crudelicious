using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}

        [Display(Name = "Name of Dish")]
        public string Name {get;set;}

        [Display(Name = "Chef's Name")]
        public string Chef {get;set;}
        public int Tastiness {get;set;}

        [Display(Name = "# of Calories")]
        public int Calories {get;set;}
        public string Description {get;set;}
        // The MySQL DATETIME type can be represented by a DateTime
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}