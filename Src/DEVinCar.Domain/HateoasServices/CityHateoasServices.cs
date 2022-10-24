

using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Interfaces.IHateoas;

namespace DEVinCar.Domain.HateoasServices
{
    public class CityHateoasServices: ICityHateoasServices
    {
        public List<HateoasDTO> GetHateoas(CityDTO entity, string baseURI)
        {
            var hateoas = new List<HateoasDTO>() {
                new HateoasDTO(){
                    Rel = "self",
                    Type = "GET",
                    URI = $"{baseURI}/api/City/{entity.Id}"
                },
                new HateoasDTO(){
                    Rel = "self",
                    Type = "PUT",
                    URI = $"{baseURI}/api/City/{entity.Id}"
                },
                new HateoasDTO(){
                    Rel = "self",
                    Type = "DELETE",
                    URI = $"{baseURI}/api/City/{entity.Id}"
                },
                new HateoasDTO(){
                    Rel = "self",
                    Type = "POST",
                     URI = $"{baseURI}/api/City/{entity.Id}"
                }
            };


            return hateoas;
        }


        public List<HateoasDTO> GetHateoasForAll( string baseURI, int take, int skip, int ultimo)
        {
            var hateoas = new List<HateoasDTO>() {
                new HateoasDTO(){
                    Rel = "self",
                    Type = "GET",
                    URI = $"{baseURI}/api/City?skip={skip}&take={take}"
                },

                new HateoasDTO(){
                    Rel = "self",
                    Type = "POST",
                    URI = $"{baseURI}/api/City/"
                }
            };
            var razao = take - skip;
            if (skip != 0)
            {
                var newSkip = skip - razao;
                if (newSkip < 0)
                    newSkip = 0;

                hateoas.Add(new HateoasDTO()
                {
                    Rel = "Prev",
                    Type = "GET",
                    URI = $"{baseURI}/api/City?skip={newSkip}&take={take - razao}"
                });
            }

            if (take < ultimo)
            {

                hateoas.Add(new HateoasDTO()
                {
                    Rel = "Next",
                    Type = "GET",
                    URI = $"{baseURI}/api/City?skip={skip + razao}&take={take + razao}"
                });
            }


            return hateoas;
        }
    }
}