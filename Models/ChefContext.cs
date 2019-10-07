using Microsoft.EntityFrameworkCore;
 
namespace ChefsAndDishes.Models
{
    public class ChefContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ChefContext(DbContextOptions options) : base(options) { }
        public DbSet<Chef> Chefs {get;set;}
        public DbSet<Dish> Dishes {get;set;}
    }
}
