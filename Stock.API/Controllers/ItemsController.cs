using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock.Application.Features.Commands.Items;

namespace Stock.API.Controllers;

// TODO: implement fluent validator
[Route("api/[controller]")]
[ApiController]
public class ItemsController(IMediator mediator) : ControllerBase
{
    // POST: api/Items
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateItemCommand command)
        => Ok(await mediator.Send(command));

    // PUT: api/Items
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateItemCommand command)
        => Ok(await mediator.Send(command));

    // DELETE: api/Items
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteItemCommand command)
        => Ok(await mediator.Send(command));

    // GET: api/Items/get-all
    [HttpGet("get-all")]
    public async Task<IActionResult> Get([FromQuery] GetAllItemsCommand command)
        => Ok(await mediator.Send(command));

    // GET: api/Items
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetItemCommand command)
        => Ok(await mediator.Send(command));
}