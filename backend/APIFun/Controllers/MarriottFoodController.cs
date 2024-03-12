using APIFun.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFun.Controllers
{
    //The name of the controller here matters because it will be the thing that we type in the website to get. Note: the route is https://IP/[name of controller]
    [Route("/[controller]")]
    [ApiController]
    public class MarriottFoodController : ControllerBase
    {
        private IFoodRepository _foodRepository;

        public MarriottFoodController(IFoodRepository temp) {
            _foodRepository = temp;
        }

        [HttpGet]
        public IEnumerable<MarriottFood> Get() {
            var foodData = _foodRepository.Foods.ToArray();

            return foodData;
        }
    }
}
