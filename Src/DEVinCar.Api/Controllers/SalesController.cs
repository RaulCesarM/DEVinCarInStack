using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.ViewModels;
using DEVinCar.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;



namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/sales")]
public class SalesController : ControllerBase
{
    private readonly ISaleService _saleService;
    private readonly IDeliveryService _deliveryService;
    public SalesController(ISaleService saleService, IDeliveryService deliveryService)
    {
        _saleService = saleService;
        _deliveryService= deliveryService;
    }

    [HttpGet("{saleId}")]
    public ActionResult<SaleViewModel> GetItensSale([FromRoute] int saleId)
    {
        var sales = _saleService.GetViewItens(saleId).ToList().FirstOrDefault();

        if (sales == null) return NotFound();
        return Ok(sales);
    }

    [HttpPost("{saleId}/item")]
    public ActionResult<SaleCar> PostSale([FromBody] SaleCarDTO body, [FromRoute] int saleId)
    {
        try
        {
            var sale = _saleService.PostSale(body, saleId);
            return Created("api/sales/{saleId}/item", sale.CarId);
        }
        catch(Exception e)
        {
            return NotFound(e);
        }
    }

    [HttpPost("{saleId}/deliver")]
    public ActionResult<DeliveryDTO> PostDeliver([FromRoute] int saleId, [FromBody] DeliveryDTO body)
    {
      int deliverId =  _deliveryService.PostDeliveryDTO(saleId,body );

        return Created("{saleId}/deliver", deliverId);
    }

    [HttpPatch("{saleId}/car/{carId}/amount/{amount}")]
    public ActionResult<SaleCar> Patch([FromRoute] int saleId, [FromRoute] int carId, [FromRoute] int amount)
    {
        var carSaleId = _context.Sales.Find(saleId);
        var carID = _context.SaleCars.Find(carId);

        if (carSaleId == null || carID == null)
        {
            return NotFound();
        }

        if (amount <= 0)
        {
            return BadRequest();
        }

        try
        {
            carID.Amount = amount;
            carID.Amount = amount;
            _context.SaleCars.Update(carID);
            _context.SaveChanges();
            return NoContent();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPatch("{saleId}/car/{carId}/price/{unitPrice}")]
    public ActionResult<SaleCar> Patch([FromRoute] int saleId, [FromRoute] int carId, [FromRoute] decimal unitPrice)
    {
        var carSaleId = _context.Sales.Find(saleId);
        var carID = _context.SaleCars.Find(carId);

        if (carSaleId == null || carID == null)
        {
            return NotFound();
        }

        if (carID.UnitPrice <= 0)
        {
            return BadRequest();
        }

        try
        {
            carID.UnitPrice = unitPrice;
            _context.SaleCars.Update(carID);
            _context.SaveChanges();
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

    }

}

