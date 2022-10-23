using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Enuns;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Validations.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DEVinCar.Api.Controllers.v2;

[ApiController]
[Route("API/v{version:apiVersion}/user")]
[ApiVersion("2", Deprecated = false)]
[Authorize]
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
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult<List<User>> Get([FromQuery] string Name, [FromQuery] DateTime? birthDateMax, [FromQuery] DateTime? birthDateMin)
    {
        var query = _userService.GetQueriableUser(Name, birthDateMax, birthDateMin);
        return Ok(query.ToList());
    }

    [HttpGet("{id}")]
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
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
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
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
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult<Sale> GetSalesBySellerId([FromRoute] int userId)
    {
        var sales = _saleService.GetReationBuyOnUser(userId);
        return Ok(sales.ToList());
    }

    [HttpPost]
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult<User> Post([FromBody] UserDTO userDto)
    {
        var newUser = _userService.GetUserByDTO(userDto);
        return Created("api/users", newUser);
    }

    [HttpPut ("{userId}/user") ]
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult<User> Update([FromBody] UserDTO userDto,[FromRoute] int userId )
    {
        _cache.Remove($"user:{userId}");
        var usermodels = _userService.GetById(userId);
        userDto.Name = usermodels.Name;
        var user = _userService.UpdateByEntity(userDto);
        return Created("api/users", user);
    }

    [HttpPost("{userId}/sales")]
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult<Sale> PostSaleUserId([FromRoute] int userId, [FromBody] SaleDTO body)
    {
        var sale = _saleService.PostSaleUserId(userId, body);
        return Created("api/sale", sale.Id);
    }

    [HttpPost("{userId}/buy")]
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult<Sale> PostBuyUserId([FromRoute] int userId, [FromBody] BuyDTO body)
    {
        var buy = _saleService.PostBuyUserId(userId, body);
        return Created("api/user/{userId}/buy", buy.Id);
    }


    [HttpDelete("{userId}")]
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult Delete([FromRoute] int userId)
    {
        _userService.Remove(userId);
        return NoContent();
    }


}





