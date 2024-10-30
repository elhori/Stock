using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.InvoiceDetails;
using Stock.Application.Resources;

namespace Stock.Application.Features.Handlers.InvoiceDetails;

public class DeleteInvoiceDetailCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteInvoiceDetailCommand, string>
{
    public async Task<string> Handle(DeleteInvoiceDetailCommand command, CancellationToken cancellationToken)
    {
        var invoiceDetail = await unitOfWork.InvoiceDetails.FindAsync(command.Id, includeRelated:false, cancellationToken: cancellationToken);

        if (invoiceDetail == null!)
            return ResponseMessages.NotFound;

        await unitOfWork.InvoiceDetails.DeleteAsync(invoiceDetail, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ResponseMessages.Deleted;
    }
}