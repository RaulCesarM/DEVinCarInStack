
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.ViewModels;
using DEVinCar.Domain.Interfaces.IBases;


namespace DEVinCar.Domain.Interfaces.IServices
{
    public interface ISaleService : IBaseService<SaleDTO, int>
    {
        public List<SaleViewModel> GetViewItens(int id);

        public IList<Sale> GetReationBuyOnUser(int userid);
        public Sale PostSaleUserId( int userId, SaleDTO body);
        public Sale PostBuyUserId(int userId, BuyDTO body);
        public SaleCar PostSale(SaleCarDTO body, int saleId);

        public List<Sale> GetByIdbuy(int userId);
        
    }
}