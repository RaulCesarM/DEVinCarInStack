using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Entities.ViewModels;
using DEVinCar.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/address")]


public class AddressesController : ControllerBase
{
    private readonly IAddressService _serviceAddress;

    public AddressesController(IAddressService service)
    {
        _serviceAddress = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public ActionResult<List<AddressViewModel>> Get([FromQuery] int? cityId,[FromQuery] int? stateId,[FromQuery] string street,[FromQuery] string cep)                                                 
    {       
        var query = _serviceAddress.GetGeralViewAddress(cityId, stateId, street, cep);
        if (!query.ToList().Any())
        {
            return NoContent();
        }      
        return Ok(query);

    }

    [HttpPatch("{addressId}")]
    [AllowAnonymous]
    public ActionResult<AddressViewModel> Patch([FromRoute] int addressId, [FromBody] AddressPatchDTO addressPatchDTO)
    {
        AddressDTO address = _serviceAddress.GetById(addressId);
        AddressViewModel addressViewModel = _serviceAddress.PatchAdressService(address ,addressPatchDTO );   
        return Ok(addressViewModel);
    }



    [HttpDelete("{addressId}")]
    [AllowAnonymous]
    public IActionResult Delete([FromRoute] int addressId)
    {
        try{
           _serviceAddress.Remove(addressId);
            return StatusCode(StatusCodes.Status204NoContent);        

        }catch{
            return StatusCode(StatusCodes.Status500InternalServerError);
        }  
         
    }
    
}


