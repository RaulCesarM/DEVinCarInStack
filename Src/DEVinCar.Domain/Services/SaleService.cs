using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.ViewModels;
using DEVinCar.Domain.Validations.Exceptions;


namespace DEVinCar.Domain.Services
{
    public class SaleService : ISaleService
    {
        private readonly ICarRepository _carRepository;
        private readonly ISaleCarRepository _saleCarRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly IUserRepository _userRepository;
        public SaleService(ISaleRepository saleRepository, IUserRepository userRepository, ISaleCarRepository saleCarRepository, ICarRepository carRepository)
        {
            _saleRepository = saleRepository;
            _userRepository = userRepository;
            _saleCarRepository = saleCarRepository;
            _carRepository = carRepository;
        }

        public IList<SaleDTO> GetAll(Pagination pagination)
        {
            return _saleRepository
            .GetAll(pagination)
            .Select(x => new SaleDTO(x))
            .ToList();
        }

        public SaleDTO GetById(int id)
        {
            return new SaleDTO(_saleRepository.GetById(id));
        }

        public int GetTotal()
        {
            return _saleRepository.GetTotal();
        }

        public void Insert(SaleDTO entity)
        {
            _saleRepository.Insert(new Sale(entity));
        }

        public void Remove(int id)
        {
            var SaleRemove = _saleRepository.GetById(id);
            _saleRepository.Remove(SaleRemove);
        }

        public void Update(SaleDTO entity, int id)
        {
            var SaleUpdate = _saleRepository.GetById(entity.Id);
            SaleUpdate.Update(entity);
            _saleRepository.Update(SaleUpdate);
        }

        public List<SaleViewModel> GetViewItens(int id)
        {
            return _saleRepository.GetItens(id).ToList();
        }

        public IList<Sale> GetReationBuyOnUser(int userid)
        {

            var sale = _saleRepository.GetReationBuyOnUser(userid);
            if (sale == null)
            {
                throw new NotFoundException($"The relation User x Buy, not found.");
            }
            return sale.ToList();

        }

        public Sale PostSaleUserId(int userId, SaleDTO body)
        {

            if (body.BuyerId == 0)
            {
                throw new IncorrectInputMessageException($"The Id no valid.");
            }

            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                throw new NotFoundException($"The user, not found.");
            }

            var bayer = _userRepository.GetById(body.BuyerId);
            if (bayer == null)
            {
                throw new NotFoundException($"The user, not found.");
            }

            if (body.SaleDate == null)
            {
                body.SaleDate = DateTime.Now;
            }

            var sale = new Sale
            {
                BuyerId = body.BuyerId,
                SellerId = userId,
                SaleDate = body.SaleDate,
            };
            _saleRepository.Insert(sale);

            return sale;

        }

        public Sale PostBuyUserId(int userId, BuyDTO body)
        {

            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                throw new NotFoundException($"The user, not found.");
            }

            var seller = _userRepository.GetById(body.SellerId);
            if (seller == null)
            {
                throw new NotFoundException($"The Seller, not found.");
            }
            if (body.SaleDate == null)
            {
                body.SaleDate = DateTime.Now;
            }

            var buy = new Sale
            {
                BuyerId = userId,
                SellerId = body.SellerId,
                SaleDate = body.SaleDate,
            };

            _saleRepository.Insert(buy);
            return buy;
        }

        public List<Sale> GetByIdbuy(int userId)
        {
            var sales = _saleRepository.GetReationBuyOnUser(userId);

            if (sales == null || sales.Count() == 0)
            {
                throw new NotFoundException($"The ID Buy, not found.");
            }
            return sales.ToList();
        }


        public SaleCar PostSale(SaleCarDTO body, int saleId)
        {
            decimal unitPrice;

            if (_saleCarRepository.CheckSaleCar(body, saleId))
            {
                if (body.CarId == 0)
                {
                    throw new BadRequestExceptions($"Not valid id");
                }

                if (body.UnitPrice <= 0 || body.Amount <= 0)
                {
                    throw new BadRequestExceptions($"Not valid price");
                }

                if (body.UnitPrice == null)
                {
                    unitPrice = _carRepository.GetById(body.CarId).SuggestedPrice;
                }
                else
                {
                    unitPrice = (decimal)body.UnitPrice;
                }


                if (body.Amount == null)
                {
                    body.Amount = 1;
                }

                var saleCar = new SaleCar
                {
                    Id = saleId,
                    Amount = body.Amount,
                    CarId = body.CarId,
                    UnitPrice = unitPrice,
                    SaleId = saleId
                };

                _saleCarRepository.Insert(saleCar);

                return saleCar;
            }
            throw new NotFoundException($"The Sale not exists.");
        }


    }
}