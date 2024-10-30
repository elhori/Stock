using MediatR;
using Microsoft.EntityFrameworkCore;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.ReceivingInvoices;
using Stock.Domain.Contracts.ReceivingInvoices;

namespace Stock.Application.Features.Handlers.ReceivingInvoices;

public class GetReceivingInvoiceCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetReceivingInvoiceCommand, ReceivingInvoiceDto>
{
    public async Task<ReceivingInvoiceDto> Handle(GetReceivingInvoiceCommand command,
        CancellationToken cancellationToken)
    {
        var receivingInvoice = await unitOfWork.ReceivingInvoices.FindAsync(
            command.Id, 
            q=> q.Include(i => i.InvoiceDetails), 
            cancellationToken);

        return receivingInvoice.ToModel();
    }
}