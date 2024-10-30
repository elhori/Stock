using MediatR;
using Microsoft.EntityFrameworkCore;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.InvoiceDetails;
using Stock.Domain.Contracts.InvoiceDetails;

namespace Stock.Application.Features.Handlers.InvoiceDetails;

public class GetInvoiceDetailCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetInvoiceDetailCommand, InvoiceDetailDto>
{
    public async Task<InvoiceDetailDto> Handle(GetInvoiceDetailCommand query, CancellationToken cancellationToken)
    {
        var invoiceDetail = await unitOfWork.InvoiceDetails.FindAsync(
            query.Id,
            q => q.Include(i => i.Item),
            cancellationToken);

        if (invoiceDetail == null!)
            return new InvoiceDetailDto(0, decimal.Zero, decimal.Zero, 0, 0, string.Empty);

        return invoiceDetail.ToModel();
    }
}