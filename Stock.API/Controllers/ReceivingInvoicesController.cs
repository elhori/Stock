using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock.Application.Features.Commands.ReceivingInvoices;

namespace Stock.API.Controllers;

// TODO: implement fluent validator
[Route("api/[controller]")]
[ApiController]
public class ReceivingInvoicesController(IMediator mediator) : ControllerBase
{
    // POST: api/ReceivingInvoices
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateReceivingInvoiceCommand command)
        => Ok(await mediator.Send(command));

    // PUT: api/ReceivingInvoices
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateReceivingInvoiceCommand command)
        => Ok(await mediator.Send(command));

    // DELETE: api/ReceivingInvoices
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteReceivingInvoiceCommand command)
        => Ok(await mediator.Send(command));

    // GET: api/ReceivingInvoices/get-all
    [HttpGet("get-all")]
    public async Task<IActionResult> Get([FromQuery] GetAllReceivingInvoicesCommand command)
        => Ok(await mediator.Send(command));

    // GET: api/ReceivingInvoices
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetReceivingInvoiceCommand command)
        => Ok(await mediator.Send(command));
}