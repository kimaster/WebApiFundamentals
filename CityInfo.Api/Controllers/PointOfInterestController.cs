using CityInfo.Api.Data;
using CityInfo.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        private readonly ILogger<PointOfInterestController> _logger;

        public PointOfInterestController(ILogger<PointOfInterestController> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = CityDataStore.Current.Cities.FirstOrDefault(xx => xx.Id == cityId);

            if (city == null)
            {
                _logger.LogInformation($" the city is not exnn{city}");
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
            _logger.LogWarning($" the city is not exnn{city}");

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
                Description = pointOfInterestCreationDto.Discription
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

        [HttpPut("{pointOfInterestid}")]
        public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId, PointOfInterestUpdateDto pointOfInterestUpdateDto)
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

            pointOfInterest.Description = pointOfInterestUpdateDto.Description;
            pointOfInterest.Name = pointOfInterestUpdateDto.Name;

            return NoContent();// Ok(pointOfInterest);
        }


        [HttpPatch("{pointOfInterestid}")]
        public ActionResult PartialUpdatePointOfInterest(int cityId, int pointOfInterestId,
            JsonPatchDocument<PointOfInterestUpdateDto> patchDocment)
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

            var pointOfInterestToPach = new PointOfInterestUpdateDto()
            {

                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description,
            };


            patchDocment.ApplyTo(pointOfInterestToPach, ModelState);

            if (ModelState.IsValid == false)
            {
                return BadRequest();

            }

            pointOfInterest.Name = pointOfInterestToPach.Name;
            pointOfInterest.Description = pointOfInterestToPach.Description;

            return NoContent();// Ok(pointOfInterest);
        }

    }








}
