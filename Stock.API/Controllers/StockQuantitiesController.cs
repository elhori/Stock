using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock.Application.Features.Commands.StockQuantities;

namespace Stock.API.Controllers;

// TODO: implement fluent validator
[Route("api/[controller]")]
[ApiController]
public class StockQuantitiesController(IMediator mediator) : ControllerBase
{
    // POST: api/StockQuantities
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateStockQuantityCommand command)
        => Ok(await mediator.Send(command));

    // PUT: api/StockQuantities
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateStockQuantityCommand command)
        => Ok(await mediator.Send(command));

    // DELETE: api/StockQuantities
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteStockQuantityCommand command)
        => Ok(await mediator.Send(command));

    // GET: api/StockQuantities/get-all
    [HttpGet("get-all")]
    public async Task<IActionResult> Get([FromQuery] GetAllStockQuantitiesCommand command)
        => Ok(await mediator.Send(command));

    // GET: api/StockQuantities
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetStockQuantityByIdCommand command)
        => Ok(await mediator.Send(command));
}