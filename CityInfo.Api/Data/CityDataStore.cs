using CityInfo.Api.Models;

namespace CityInfo.Api.Data
{
    public class CityDataStore
    {
        public List<CityDto> Cities { get; set; }
        public static CityDataStore Current { get; } = new CityDataStore();
        public CityDataStore()
        {


            Cities =
            [
                new()
                {
                    Id = 1,
                    Name = "New York",
                },
                new()      {
                    Id = 2,
                    Name="Algiers"
                },
                new()      {
                    Id = 3,
                    Name = "Paris"
                },
                new()
                {
                    Id = 4,
                    Name = "Antwerp",

                },
            ];
        }





    }
}
