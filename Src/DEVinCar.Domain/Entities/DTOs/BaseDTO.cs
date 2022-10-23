
namespace DEVinCar.Domain.Entities.DTOs
{
    public class BaseDTO <TEntity> where TEntity : class
    {
        public TEntity Data { get; set; }
        public IList<HateoasDTO> Links { get; set; }
    }
}