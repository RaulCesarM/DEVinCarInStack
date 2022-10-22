using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Validations.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DEVinCar.Api.Controllers
{
    [ApiController]
    [Route("deliver")]
    public class DeliverController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        public DeliverController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<Delivery> Get([FromQuery] int? addressId,[FromQuery] int? saleId)
        {
            var query = _deliveryService.GetDelivery(addressId, saleId);
            return Ok(query.ToList());       
        }
    }
}

