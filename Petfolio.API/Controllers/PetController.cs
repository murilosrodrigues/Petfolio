using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UsesCases.Pet.Delete;
using Petfolio.Application.UsesCases.Pet.GetAll;
using Petfolio.Application.UsesCases.Pet.GetById;
using Petfolio.Application.UsesCases.Pet.Register;
using Petfolio.Application.UsesCases.Pet.Update;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestPetJson request)
    {
        //business logic

        //var useCase = new RegisterPetUseCase();
        //var response = useCase.Execute(request);
        var response = new RegisterPetUseCase().Execute(request);

        return Created(string.Empty, response);
    }


    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromBody] int id, [FromBody] RequestPetJson request)
    {
        var useCase = new UpdatePetUseCase().Execute(id, request);

        return NoContent();
    }


    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllPetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllPetsUseCase().Excecute();

        if (useCase.Pets.Any())
            return Ok(useCase);

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        var response = new GetPetByIdUseCase().Execute(id);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var useCase = new DeletePetByIdUseCase();
        useCase.Execute(id);

        return NoContent();
    }
}
