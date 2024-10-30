using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.ReceivingInvoices;
using Stock.Application.Resources;

namespace Stock.Application.Features.Handlers.ReceivingInvoices;

public class UpdateReceivingCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateReceivingInvoiceCommand, string>
{
    public async Task<string> Handle(UpdateReceivingInvoiceCommand command, CancellationToken cancellationToken)
    {
        var receivingInvoice = await unitOfWork.ReceivingInvoices.FindAsync(command.Id, false, cancellationToken);

        if (receivingInvoice == null!)
            return ResponseMessages.NotFound;

        receivingInvoice.Update(command);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ResponseMessages.Updated;
    }
}