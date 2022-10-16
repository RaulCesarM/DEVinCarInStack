using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("user")]
//[Authorize(Roles = "Gerente")]


public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ISaleService _saleService;
    private readonly IMemoryCache _cache;

    public UserController(IUserService userService, ISaleService saleService, IMemoryCache cache)
    {
        _userService = userService;
        _saleService = saleService;
        _cache = cache;
    }

    [HttpGet]
    public ActionResult<List<User>> Get([FromQuery] string Name, [FromQuery] DateTime? birthDateMax, [FromQuery] DateTime? birthDateMin)
    {
        var query = _userService.GetQueriableUser(Name, birthDateMax, birthDateMin);
        return Ok(query.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetById([FromRoute] int id)
    {
        User user;
        if(!_cache.TryGetValue<User>($"user: {id}", out user)){
         user = _userService.GetUserById(id);
         _cache.Set<User>($"user: {id}", user, new TimeSpan(0,0,40));
        if (user == null) return NotFound();
        }
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

    [HttpPut ("{userId}/user") ]
    public ActionResult<User> Update([FromBody] UserDTO userDto,[FromRoute] int userId )
    {
        _cache.Remove($"user:{userId}");
        var usermodels = _userService.GetById(userId);
        userDto.Name = usermodels.Name;
        var user = _userService.UpdateByEntity(userDto);
        return Created("api/users", user);
    }

    [HttpPost("{userId}/sales")]
    public ActionResult<Sale> PostSaleUserId([FromRoute] int userId, [FromBody] SaleDTO body)
    {
        var sale = _saleService.PostSaleUserId(userId, body);
        return Created("api/sale", sale.Id);
    }

    [HttpPost("{userId}/buy")]
    public ActionResult<Sale> PostBuyUserId([FromRoute] int userId, [FromBody] BuyDTO body)
    {
        var buy = _saleService.PostBuyUserId(userId, body);
        return Created("api/user/{userId}/buy", buy.Id);
    }


    [HttpDelete("{userId}")]
    public ActionResult Delete([FromRoute] int userId)
    {
        _userService.Remove(userId);
        return NoContent();
    }


}





