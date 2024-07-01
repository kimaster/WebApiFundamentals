using CityInfo.Api.Data;
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

            //return new JsonResult(
            //   //anonymoise abject
            //   new List<object>
            //   {
            //       new {id=1,Name="hakim"},
            //       new {id=2,Name="maakeb"}

            //   }
            //    );
            var temp = new JsonResult(CityDataStore.Current.Cities);
            temp.StatusCode = 200;
            return
        }


        [HttpGet("{id}")]// now no need as this only one get 
        public JsonResult GetCity(int id)
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


            return new JsonResult(CityDataStore.Current.Cities.Where(xx => xx.Id == id));
        }

    }
}
