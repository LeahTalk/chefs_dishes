using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace ChefsAndDishes.Models
{
    public class Chef
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int ChefId { get; set; }
        [Required(ErrorMessage = "First name is required!")]
        [Display(Name = "First Name:")] 
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required!")]
        [Display(Name = "Last Name:")] 
        public string LastName { get; set; }
        [Required(ErrorMessage = "Birth Date is required!")]
        [NoFutureDate]
        [Display(Name = "Birth Date:")] 
        [MinLength(1)]
        public String Birthday { get; set; }
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        public List<Dish> CreatedDishes {get;set;}
    }

    public class NoFutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null) {
                return new ValidationResult("A date must be entered!");
            }
            DateTime date = DateTime.Parse((string)value);
            if (date > DateTime.Now)
                return new ValidationResult("Date cannot be in the future!");
            if((DateTime.Now.Year - date.Year - 1) +
                (((DateTime.Now.Month > date.Month) ||
                ((DateTime.Now.Month == date.Month) && (DateTime.Now.Day >= date.Day))) ? 1 : 0) < 18) 
                return new ValidationResult("Chef must be 18 years or older!");
            Console.WriteLine((DateTime.Now.Year - date.Year - 1) +
                (((DateTime.Now.Month > date.Month) ||
                ((DateTime.Now.Month == date.Month) && (DateTime.Now.Day >= date.Day))) ? 1 : 0) < 18);
            return ValidationResult.Success;
        }
    }
}