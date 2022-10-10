using DEVinCar.Domain.Interfaces.IBases;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.ViewModels;

namespace DEVinCar.Domain.Interfaces.IRepositories
{
    public interface ISaleRepository : IBaseRepository<Sale, int>
    {
        public IList<SaleViewModel> GetItens(int saleId);

        public IList<Sale> GetReationBuyOnUser(int userId);

       
    }
}