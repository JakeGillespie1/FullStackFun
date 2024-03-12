using Microsoft.EntityFrameworkCore;

namespace APIFun.Data
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }

        //We are taking all the individual food items together and then calling the table with the food items 'Foods'.
        public DbSet<MarriottFood> Foods { get; set; }

    }
}
