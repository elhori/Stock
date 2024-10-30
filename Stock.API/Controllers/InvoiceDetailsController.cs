using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock.Application.Features.Commands.InvoiceDetails;

namespace Stock.API.Controllers;

// TODO: implement fluent validator
[Route("api/[controller]")]
[ApiController]
public class InvoiceDetailsController(IMediator mediator) : ControllerBase
{
    // POST: api/InvoiceDetails
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateInvoiceDetailCommand command)
        => Ok(await mediator.Send(command));

    // PUT: api/InvoiceDetails
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateInvoiceDetailCommand command)
        => Ok(await mediator.Send(command));

    // DELETE: api/InvoiceDetails
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteInvoiceDetailCommand command)
        => Ok(await mediator.Send(command));

    // GET: api/InvoiceDetails/get-all
    [HttpGet("get-all")]
    public async Task<IActionResult> Get([FromQuery] GetAllInvoiceDetailsCommand command)
        => Ok(await mediator.Send(command));

    // GET: api/InvoiceDetails
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetInvoiceDetailCommand command)
        => Ok(await mediator.Send(command));
}