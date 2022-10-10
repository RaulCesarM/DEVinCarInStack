
using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Infra.Data.Context;
using DEVinCar.Domain.Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DEVinCar.Infra.Data.Repository
{
    public class SaleRepository : BaseGenericCrudRepository<Sale, int>, ISaleRepository
    {
        private readonly DevInCarDbContext _context;
        public SaleRepository(DevInCarDbContext context) : base(context)
        {
            _context = context;

        }

        public int GetTotal()
        {
            return _context.Sales.Count();
        }

        public IList<SaleViewModel> GetItens(int saleId)
        {
            var sales = _context.Sales
                       .Include(s => s.Cars)
                       .Include(s => s.UserBuyer)
                       .Include(s => s.UserSeller)
                       .Where(s => s.Id == saleId)
                       .Select(s => new SaleViewModel{
                        SellerName = s.UserSeller.Name,
                        BuyerName = s.UserBuyer.Name,
                        SaleDate = s.SaleDate,
                        Itens = s.Cars.Select(sc => new CarViewModel{
                                                    Name = sc.Car.Name,
                                                    UnitPrice = (decimal)sc.UnitPrice,
                                                    Amount = sc.Amount,
                                                    Total = sc.Sum((decimal)sc.UnitPrice, sc.Amount)}).ToList()});
            return sales.ToList();
          }

        public IList<Sale> GetReationBuyOnUser(int userId)
        {
            var sales = _context.Sales.Where(s => s.BuyerId == userId);
            return sales.ToList();
        }

       
    }
}