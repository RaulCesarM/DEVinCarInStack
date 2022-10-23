

namespace DEVinCar.Domain.Entities.DTOs
{
    public abstract class BaseHateoas
    {
        public IList<HateoasDTO> Links { get; set; }
    }
}