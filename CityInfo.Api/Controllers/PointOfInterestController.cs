using CityInfo.Api.Data;
using CityInfo.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = CityDataStore.Current.Cities.FirstOrDefault(xx => xx.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(x => x.Id == pointOfInterestId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }
        [HttpPost()]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, [FromBody] PointOfInterestCreationDto pointOfInterestCreationDto)

        {
            var city = CityDataStore.Current.Cities.FirstOrDefault(xx => xx.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }



            var pointOfInterestId = CityDataStore
                    .Current
                    .Cities
                    .SelectMany(p => p.PointsOfInterest)
                    .Max(x => x.Id);

            var pointOfInterest = new PointOfInterestDto
            {
                Id = ++pointOfInterestId,
                Name = pointOfInterestCreationDto.Name,
                Discription = pointOfInterestCreationDto.Discription
            };

            city.PointsOfInterest.Add(pointOfInterest);

            return CreatedAtRoute(
                nameof(GetPointOfInterest),
                new
                {
                    cityId,
                    pointOfInterestId = pointOfInterest.Id,
                },
                pointOfInterest);


        }
    }








}
