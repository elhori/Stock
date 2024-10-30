using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.ReceivingInvoices;
using Stock.Application.Resources;

namespace Stock.Application.Features.Handlers.ReceivingInvoices;

public class DeleteReceivingInvoiceCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteReceivingInvoiceCommand, string>
{
    public async Task<string> Handle(DeleteReceivingInvoiceCommand command, CancellationToken cancellationToken)
    {
        var receivingInvoice = await unitOfWork.ReceivingInvoices.FindAsync(command.Id, false, cancellationToken);

        if (receivingInvoice == null!)
            return ResponseMessages.NotFound;

        await unitOfWork.ReceivingInvoices.DeleteAsync(receivingInvoice, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ResponseMessages.Deleted;
    }
}