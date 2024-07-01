using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers
{
    /*
     1- ControllerBase is 
     2- [ApiController] : requiring  certain type for router, autmcly  rerning the code 
        - 
     */

    [ApiController]
  //  [Route("api/[controller]")]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        // [HttpGet("api/cities")] --move this to controller level

        [HttpGet()]// now no need as this only one get 
        public JsonResult GetCities()
        {

            return new JsonResult(
               //anonymoise abject
               new List<object>
               {
                   new {id=1,Name="hakim"},
                   new {id=2,Name="maakeb"}

               }
                );
        }

    }
}
