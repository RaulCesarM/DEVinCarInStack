using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Domain.Services
{
    public class SaleCarService : ISaleCarService
    {
        private readonly ISaleCarRepository _saleCarRepository;

        public SaleCarService(ISaleCarRepository saleCarRepository)
        {
            _saleCarRepository = saleCarRepository;
        }
        public IList<SaleCarDTO> GetAll(Pagination pagination)
        {
            return _saleCarRepository
          .GetAll(pagination)
          .Select(x => new SaleCarDTO(x))
          .ToList();
        }

        public SaleCarDTO GetById(int id)
        {
            return new SaleCarDTO(_saleCarRepository.GetById(id));
        }

        public int GetTotal()
        {
            return _saleCarRepository.GetTotal();
        }

        public void Insert(SaleCarDTO entity)
        {
            _saleCarRepository.Insert(new SaleCar(entity));
        }

        public void Remove(int id)
        {

            var SaleCarRemove = _saleCarRepository.GetById(id);
            _saleCarRepository.Remove(SaleCarRemove);
        }

        public void Update(SaleCarDTO entity, int id)
        {
            var SaleCarUpdate = _saleCarRepository.GetById(entity.SaleId);
            SaleCarUpdate.Update(entity);
            _saleCarRepository.Update(SaleCarUpdate);
        }
    }
}