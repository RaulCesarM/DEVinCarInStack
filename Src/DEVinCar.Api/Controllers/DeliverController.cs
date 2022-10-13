using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;


namespace DEVinCar.Api.Controllers
{
    [ApiController]
    [Route("api/deliver")]
    public class DeliverController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        public DeliverController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public ActionResult<Delivery> Get([FromQuery] int? addressId,[FromQuery] int? saleId)
        {
            var query = _deliveryService.GetDelivery(addressId, saleId);
            return Ok(query.ToList());       
        }
    }
}

