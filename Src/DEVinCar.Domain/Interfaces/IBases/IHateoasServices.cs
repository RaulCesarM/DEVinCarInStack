
using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Domain.Interfaces.IBases
{
    

    public interface IHateoasServices<TEntity> where TEntity : class
    {
        public List<HateoasDTO> GetHateoas(TEntity entity, string baseURI, int id);
        public List<HateoasDTO> GetHateoasForAll(TEntity entity, string baseURI, int take, int skip, int ultimo);
    }
}