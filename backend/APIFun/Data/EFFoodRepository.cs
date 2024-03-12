namespace APIFun.Data
{
    public class EFFoodRepository : IFoodRepository
    {
        //_foodContext is an instance of the database in .NET
        private FoodContext _foodContext;

        //Constructor that pulls in the FoodContext file
        public EFFoodRepository(FoodContext temp) { 
            _foodContext = temp;
        }

        //Ge the Foods table from the FoodContext file.
        public IEnumerable<MarriottFood> Foods => _foodContext.Foods;
    }
}
