
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.ViewModels;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/state")]
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
    public ActionResult<int> PostCity([FromRoute] int stateId, [FromBody] CityDTO cityDTO)
    {
        var Id = _stateService.PostCity(stateId, cityDTO);
        return Created("api/{stateId}/city", Id);
    }



    [HttpPost("{stateId}/city/{cityId}/address")]
    public ActionResult<int> PostAdress([FromRoute] int stateId, [FromRoute] int cityId, [FromBody] AddressDTO body)
    {
        var address = _addressService.PostAdress(stateId, cityId, body);
        return Created($"api/state/{stateId}/city/{cityId}/", address);
    }



    [HttpGet("{stateId}/city/{cityId}")]
    public ActionResult<GetCityByIdViewModel> GetCityById([FromRoute] int stateId, [FromRoute] int cityId)
    {
        var CityById = _addressService.GetCityById(stateId, cityId);
        return Ok(CityById);
    }

    [HttpGet("{stateId}")]
    public ActionResult<GetStateByIdViewModel> GetStateById([FromRoute] int stateId)
    {
        var filterState = _stateService.GetById(stateId);
        var response = new GetStateByIdViewModel(
            filterState.Id,
            filterState.Name,
            filterState.Initials
            );

        return Ok(response);
    }

    [HttpGet]
    public ActionResult<List<GetStateViewModel>> Get([FromQuery] string name)
    {
        try
        {
            var getStateViewModels = _stateService.GetStateByName(name);
            return Ok(getStateViewModels);
        }
        catch
        {
            return NoContent();
        }
    }


    

    [HttpGet("{stateId}/city")]
    public ActionResult<GetCityByIdViewModel> GetCityByStateId([FromRoute] int stateId, [FromQuery] string name)

    {
            var queryResponse = _addressService.GetCityByStateId(stateId, name);
            return Ok(queryResponse);  
    }

}

