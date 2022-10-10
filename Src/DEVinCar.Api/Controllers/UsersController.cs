
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/user")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ISaleService _saleService;

    public UserController( IUserService userService, ISaleService saleService)
    {
        _userService = userService;
        _saleService = saleService;
    }

    [HttpGet]
    public ActionResult<List<User>> Get([FromQuery] string Name,[FromQuery] DateTime? birthDateMax, [FromQuery] DateTime? birthDateMin )
    {
        var query = _userService.GetQueriableUser(Name,birthDateMax,birthDateMin);       

        return Ok(query.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetById([FromRoute] int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

  

    [HttpGet("{userId}/buy")]
    public ActionResult<Sale> GetByIdbuy([FromRoute] int userId)
    {
        var sales = _saleService.GetReationBuyOnUser(userId);

        if (sales == null || sales.Count() == 0)
        {
            return NoContent();
        }
        return Ok(sales.ToList());
    }

    [HttpGet("{userId}/sales")]
    public ActionResult<Sale> GetSalesBySellerId([FromRoute] int userId)
    {
        var sales = _saleService.GetReationBuyOnUser(userId);        
        return Ok(sales.ToList());
    }

    [HttpPost]
    public ActionResult<User> Post([FromBody] UserDTO userDto)    
    {

        var newUser = _userService.GetUserByDTO(userDto);  
        return Created("api/users", newUser);
    }

    [HttpPost("{userId}/sales")]
    public ActionResult<Sale> PostSaleUserId([FromRoute] int userId,[FromBody] SaleDTO body)
    {
       var sale = _saleService.PostSaleUserId(userId, body);
        return Created("api/sale", sale.Id);
    }

    [HttpPost("{userId}/buy")]
   public ActionResult<Sale> PostBuyUserId([FromRoute] int userId,[FromBody] BuyDTO body)
    {

        var buy= _saleService.PostBuyUserId(userId,body);
        return Created("api/user/{userId}/buy", buy.Id);
    }
     

    [HttpDelete("{userId}")]
    public ActionResult Delete([FromRoute] int userId)
    {
         _userService.Remove(userId);
        return NoContent();
    }


}





