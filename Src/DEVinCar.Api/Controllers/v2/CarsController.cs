using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.Entities.Enuns;
using DEVinCar.Domain.Validations.Security;
using AutoMapper;
using Newtonsoft.Json;
using DEVinCar.Domain.Interfaces.IHateoas;

namespace DEVinCar.Api.Controllers.v2;


[ApiController]
[Route("API/v{version:apiVersion}/car")]
[ApiVersion("2", Deprecated = true)]
[Authorize]
public class CarController : ControllerBase
{

    private readonly ICarService _carService;
    private readonly ICarHateoasServices _hateoas;

    private readonly IMapper _mapper;

    public CarController(ICarService carService, IMapper mapper, ICarHateoasServices hateoas)
    {   _hateoas = hateoas; 
        _mapper = mapper;
        _carService = carService;
    }

    [HttpGet]
    [AllowAnonymous]
    public ActionResult<List<CarDTO>> Get([FromQuery] string name, [FromQuery] decimal? priceMin, [FromQuery] decimal? priceMax, int skip = 0, int take = 5)
    {
        try
        {
            var page = new Pagination(take, skip);
            var Total = _carService.GetTotal();
            var uri = $"{Request.Scheme}://{Request.Host}";
            Response.Headers.Add("X-Paginacao-TotalRegistros", Total.ToString());
            Response.Cookies.Append("Coockie", JsonConvert.SerializeObject(page));// cria coockie
            var cars = new BaseDTO<IList<CarDTO>>(){
                Data = _carService.GetGeralViewCarPage(name, priceMin, priceMax, page),
                Links = _hateoas.GetHateoasForAll(uri, take, skip, Total)
            };
            foreach (var car in cars.Data)
            {
                car.Links = _hateoas.GetHateoas(car, uri);
            }

           
            return Ok(cars);

        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{carId}")]
    [AllowAnonymous]
    public ActionResult<CarDTO> GetById([FromRoute] int carId)
    {
        try
        {
           var coock = Request.Cookies["Coockie"]; ///use coockie
           var uri = $"{Request.Scheme}://{Request.Host}";
           var car = _mapper.Map<CarDTO>(_carService.GetCarById(carId));
           car.Links = _hateoas.GetHateoas(car,uri );                
           
            return Ok(car);

        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }


    [HttpPost]
    [PermissaoAuthorize(Permission.Administrador)]
    public ActionResult<Car> Post([FromBody] CarDTO car)
    {
        try
        {
            _carService.Insert(_mapper.Map<CarDTO>(car));
            return StatusCode(StatusCodes.Status201Created);

        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

    }

    [HttpDelete("{carId}")]
    [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult Delete([FromRoute] int carId)
    {

        _carService.Remove(carId);
        if (_carService.GetById(carId) == null)
        {

            return Ok($"removed with successor,{carId}");
        }
        else
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }



    }

    [HttpPut("{carId}")]
   // [AllowAnonymous]
     [PermissaoAuthorize(Permission.Gerente, Permission.Diretor)]
    public ActionResult<Car> EditCarNameOrPrice([FromBody] CarDTO carDto, [FromRoute] int carId)
    {
        try
        {
            var car = _carService.GetCarById(carId);
            car.Name = carDto.Name;
            car.SuggestedPrice = carDto.SuggestedPrice;

            _carService.Update(_mapper.Map<CarDTO>(car), carId);
            return Ok("Edited");

        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }

    // private List<HateoasDTO> GetHateoas(int Id, string UriBase)
    // {
    //     return new List<HateoasDTO>()
    //     {
    //         new HateoasDTO(){
    //             Rel = "self",
    //             Type = "GET",
    //             URI = $"{UriBase}/API/v2/car/{Id}"

    //         },
    //         new HateoasDTO(){
    //             Rel = "self",
    //             Type = "POST",
    //             URI =  $"{UriBase}/API/v2/car/{Id}"

    //         },
    //         new HateoasDTO(){
    //             Rel = "self",
    //             Type = "PUT",
    //             URI =  $"{UriBase}/API/v2/car/{Id}"

    //         },
    //         new HateoasDTO(){
    //             Rel = "self",
    //             Type = "DELETE",
    //             URI =  $"{UriBase}/API/v2/car/{Id}"

    //         }

    //     };
    // }
}
