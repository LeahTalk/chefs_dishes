using System.ComponentModel.DataAnnotations;
using System;
namespace ChefsAndDishes.Models
{
    public class Dish
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int DishId { get; set; }
        // MySQL VARCHAR and TEXT types can be represeted by a string
        [Required(ErrorMessage = "The dish name is required!")]
        [Display(Name = "Name of Dish:")] 
        public string Name { get; set; }
        public int ChefId { get; set; }
        public Chef Creator { get; set; }
        [Display(Name = "Tastiness:")] 
        public int Tastiness { get; set; }
        [Display(Name = "Number of Calories:")] 
        [Range(0, int.MaxValue, ErrorMessage = "Calories must be a positive number")]
        public int Calories { get; set; }
        [Display(Name = "Description:")] 
        public string Description { get; set; }
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
}