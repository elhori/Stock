using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.InvoiceDetails;
using Stock.Application.Resources;

namespace Stock.Application.Features.Handlers.InvoiceDetails;

public class UpdateInvoiceDetailCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateInvoiceDetailCommand, string>
{
    public async Task<string> Handle(UpdateInvoiceDetailCommand command, CancellationToken cancellationToken)
    {
        var invoiceDetail = await unitOfWork.InvoiceDetails.FindAsync(command.Id, includeRelated:false, cancellationToken: cancellationToken);

        if (invoiceDetail == null!)
            return ResponseMessages.NotFound;

        invoiceDetail.Update(command);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ResponseMessages.Updated;
    }
}