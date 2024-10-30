using Stock.Application.Features.Commands.InvoiceDetails;
using Stock.Domain;
using Stock.Domain.Contracts.InvoiceDetails;
using Stock.Domain.Entities;

namespace Stock.Application.Contracts.Repositories;

public interface IInvoiceDetailRepository : IAsyncRepository<InvoiceDetail>
{
    Task<PaginatedResult<InvoiceDetailDto>> GetInvoiceDetailsForInvoice(GetAllInvoiceDetailsCommand command, CancellationToken cancellationToken = default);
}