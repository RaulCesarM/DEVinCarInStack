using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.ViewModels;
using DEVinCar.Domain.Validations.Security;
using DEVinCar.Domain.Entities.Enuns;
using Microsoft.AspNetCore.Authorization;

namespace DEVinCar.Api.Controllers.v2;

[ApiController]
[Route("API/v{version:apiVersion}/state")]
[ApiVersion("2", Deprecated = false)]
[Authorize]
public class StatesController : ControllerBase
{
    private readonly IStateService _stateService;
    private readonly IAddressService _addressService;

    public StatesController(IStateService stateService, IAddressService addressService)
    {
        _stateService = stateService;
        _addressService = addressService;
    }

    [HttpPost("{stateId}/city")]
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult<int> PostCity([FromRoute] int stateId, [FromBody] CityDTO cityDTO)
    {
        try
        {
            var Id = _stateService.PostCity(stateId, cityDTO);
            return Created("api/{stateId}/city", Id);

        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

       
    }



    [HttpPost("{stateId}/city/{cityId}/address")]
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult<int> PostAdress([FromRoute] int stateId, [FromRoute] int cityId, [FromBody] AddressDTO body)
    {
        try
        {
            var address = _addressService.PostAdress(stateId, cityId, body);
            return Created($"api/state/{stateId}/city/{cityId}/", address);

        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        
        
    }



    [HttpGet("{stateId}/city/{cityId}")]
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult<GetCityByIdViewModel> GetCityById([FromRoute] int stateId, [FromRoute] int cityId)
    {
        try
        {
            var CityById = _addressService.GetCityById(stateId, cityId);
            return Ok(CityById);

        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        
       
    }

    [HttpGet("{stateId}")]
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult<GetStateByIdViewModel> GetStateById([FromRoute] int stateId)
    {

        try
        {

            var filterState = _stateService.GetById(stateId);
            var response = new GetStateByIdViewModel(filterState.Id, filterState.Name, filterState.Initials);
            return Ok(response);

        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

    }

    [HttpGet]
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult<List<GetStateViewModel>> Get([FromQuery] string name)
    {
        try
        {
            var getStateViewModels = _stateService.GetStateByName(name);
            return Ok(getStateViewModels);
        }
        catch
        {

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{stateId}/city")]
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult<GetCityByIdViewModel> GetCityByStateId([FromRoute] int stateId, [FromQuery] string name)
    {
        try
        {
            var queryResponse = _addressService.GetCityByStateId(stateId, name);
            return Ok(queryResponse);
        }
        catch
        {

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        
    }

}

