using Stock.Application.Features.Commands.ReceivingInvoices;
using Stock.Domain;
using Stock.Domain.Contracts.ReceivingInvoices;
using Stock.Domain.Entities;

namespace Stock.Application.Contracts.Repositories;

public interface IReceivingInvoiceRepository : IAsyncRepository<ReceivingInvoice>
{
    Task<PaginatedResult<ReceivingInvoiceDto>> GetReceivingInvoices(GetAllReceivingInvoicesCommand command, CancellationToken cancellationToken = default);
}