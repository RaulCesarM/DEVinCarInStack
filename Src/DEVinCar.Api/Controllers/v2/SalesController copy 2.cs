using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Enuns;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.ViewModels;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Validations.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace DEVinCar.Api.Controllers.v2
{
    [ApiController]
    [Route("API/v{version:apiVersion}/sales")]   
    [ApiVersion("2", Deprecated = false)]
    [Authorize]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;
        private readonly IDeliveryService _deliveryService;
        public SalesController(ISaleService saleService, IDeliveryService deliveryService)
        {
            _saleService = saleService;
            _deliveryService = deliveryService;
        }

        [HttpGet("{saleId}")]
        [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
        public ActionResult<SaleViewModel> GetItensSale([FromRoute] int saleId)
        {
            var sales = _saleService.GetViewItens(saleId).ToList().FirstOrDefault();

            if (sales == null) return NotFound();
            return Ok(sales);
        }

        [HttpPost("{saleId}/item")]
        [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
        public ActionResult<SaleCar> PostSale([FromBody] SaleCarDTO body, [FromRoute] int saleId)
        {
            try
            {
                var sale = _saleService.PostSale(body, saleId);
                return Created("api/sales/{saleId}/item", sale.CarId);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpPost("{saleId}/deliver")]
        [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
        public ActionResult<DeliveryDTO> PostDeliver([FromRoute] int saleId, [FromBody] DeliveryDTO body)
        {
            int deliverId = _deliveryService.PostDeliveryDTO(saleId, body);
            return Created("{saleId}/deliver", deliverId);
        }

        [HttpPatch("{saleId}/car/{carId}/amount/{amount}")]
        public ActionResult<SaleCar> PatchAmount([FromRoute] int saleId, [FromRoute] int carId, [FromRoute] int amount)
        {
            try
            {
                _saleService.PatchAmount(saleId, carId, amount);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{saleId}/car/{carId}/price/{unitPrice}")]
        [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
        public ActionResult<SaleCar> Patch([FromRoute] int saleId, [FromRoute] int carId, [FromRoute] decimal unitPrice)
        {
            try
            {
                _saleService.PatchtUnitPrice(saleId, carId, unitPrice);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }




}
