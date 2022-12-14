
using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Domain.Interfaces.IBases
{
    public interface IBaseHateoas<TEntity> where TEntity : class
    {
        public List<HateoasDTO> GetHateoas(TEntity entity, string baseURI);
        public List<HateoasDTO> GetHateoasForAll( string baseURI, int take, int skip, int ultimo);
    }
}