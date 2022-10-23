using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Validations.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DEVinCar.Api.Controllers.v2
{
    [ApiController]
    [Route("API/v{version:apiVersion}/deliver")]
    [Route("api/deliver")]
    [ApiVersion("2", Deprecated = true)]
    [Authorize]
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

