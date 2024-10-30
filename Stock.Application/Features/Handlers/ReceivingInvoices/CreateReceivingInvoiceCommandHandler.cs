using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.ReceivingInvoices;
using Stock.Application.Resources;
using Stock.Domain.Entities;

namespace Stock.Application.Features.Handlers.ReceivingInvoices;

public class CreateReceivingInvoiceCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateReceivingInvoiceCommand, string>
{
    public async Task<string> Handle(CreateReceivingInvoiceCommand command, CancellationToken cancellationToken)
    {
        var receivingInvoice = new ReceivingInvoice(command);

        await unitOfWork.ReceivingInvoices.AddAsync(receivingInvoice, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ResponseMessages.Added;
    }
}