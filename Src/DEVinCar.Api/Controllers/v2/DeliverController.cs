using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DEVinCar.Api.Controllers.v2
{
    [ApiController]
    [Route("API/v{version:apiVersion}/deliver")]    
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
        public ActionResult<DeliveryDTO> GetAllDeliverys([FromQuery] int? addressId,[FromQuery] int? saleId, int skip = 0, int take = 5)
        {
            try
            {
                var page = new Pagination(take, skip);
                var Total = _deliveryService.GetTotal();
                Response.Headers.Add("X-Paginacao-TotalRegistros", Total.ToString());
                var query = _deliveryService.GetDelivery(addressId, saleId,page);
                return Ok(query.ToList());

            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
                 
        }
    }
}

