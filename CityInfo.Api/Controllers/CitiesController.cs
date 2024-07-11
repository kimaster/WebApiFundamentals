using CityInfo.Api.Data;
using CityInfo.Api.Models;
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

        public CitiesController(CityDataStore cityDataStore)
        {
            CityDataStore = cityDataStore;
        }

        public CityDataStore CityDataStore { get; }

        // [HttpGet("api/cities")] --move this to controller level

        [HttpGet()]// now no need as this only one get 
                   //    public JsonResult GetCities()
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {

            //return new JsonResult(
            //   //anonymoise abject
            //   new List<object>
            //   {
            //       new {id=1,Name="hakim"},
            //       new {id=2,Name="maakeb"}

            //   }
            //    );
            var temp = new JsonResult(CityDataStore.Cities);
            temp.StatusCode = 200;
            return Ok(CityDataStore.Cities);
        }


        [HttpGet("{id}")]// now no need as this only one get 
        public ActionResult<CityDto> GetCity(int id)
        {

            //return new JsonResult(
            //   //anonymoise abject
            //   new List<object>
            //   {
            //       new {id=1,Name="hakim"},
            //       new {id=2,Name="maakeb"}

            //   }
            //    );

            // common mistakes 
            // dont send back 200 when some thing went wrong 
            // dont send back  500  internal server error when the client make mistakes

            /*//1- level 100 :information
            //2- 200 success:
            //
                200 ok 
            201 created
            204 no conteent succes with no return

                 //2- 300 redirection :
            //
           //2- 400 client mistake redirection :
            // 400 bad request
            // 401 unauthoriside 
            //403 forbident
            //404 not fouund
            // 409  confilct 
          


            //2- 500 server error :
            / 
            // 500 internal server error 
            */

            var city = CityDataStore.Cities.FirstOrDefault(xx => xx.Id == id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);


        }

    }
}
