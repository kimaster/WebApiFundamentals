using CityInfo.Api.Models;

namespace CityInfo.Api.Data
{
    public class CityDataStore
    {
        public List<CityDto> Cities { get; set; }
        //public static CityDataStore Current { get; } = new CityDataStore();
        public CityDataStore()
        {


            Cities =
            [
                new()
                {
                    Id = 1,
                    Name = "New York",
                    PointsOfInterest= new List<PointOfInterestDto>()
                    {
                       new PointOfInterestDto() { Id=1, Name="11"},
                       new PointOfInterestDto() { Id=2, Name="2"},
                    }
                },
                new()      {
                    Id = 2,
                    Name="Algiers",
                    PointsOfInterest= new List<PointOfInterestDto>()
                    {
                       new PointOfInterestDto() { Id=3, Name="2"},
                       new PointOfInterestDto(){ Id=4, Name="2"},
                    }
                },
                new()      {
                    Id = 3,
                    Name = "Paris",
                    PointsOfInterest= new List<PointOfInterestDto>()
                    {
                       new PointOfInterestDto(){ Id=5, Name="2"},
                       new PointOfInterestDto(){ Id=6, Name="2"},
                    }
                },
                new()
                {
                    Id = 4,
                    Name = "Antwerp",
                    PointsOfInterest= new List<PointOfInterestDto>()
                    {
                       new PointOfInterestDto(){ Id=7, Name="2"},
                       new PointOfInterestDto(){ Id=8, Name="2"},
                    }

                },
            ];
        }





    }
}
