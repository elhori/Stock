using Microsoft.EntityFrameworkCore;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.ReceivingInvoices;
using Stock.Domain;
using Stock.Domain.Contracts.Items;
using Stock.Domain.Contracts.ReceivingInvoices;
using Stock.Domain.Entities;

namespace Stock.Infrastructure.Persistence.Repositories;

public class ReceivingInvoiceRepository(AppDbContext context) : AsyncRepository<ReceivingInvoice>(context), IReceivingInvoiceRepository
{
    public async Task<PaginatedResult<ReceivingInvoiceDto>> GetReceivingInvoices(GetAllReceivingInvoicesCommand command, CancellationToken cancellationToken = default)
    {
        var data = context.ReceivingInvoices
            .Include(i => i.InvoiceDetails)
            .AsNoTracking();

        var total = await data.CountAsync(cancellationToken);

        var skip = command.PageSize * (command.CurrentPage - 1);

        if (!await data.Skip(skip).AnyAsync(cancellationToken: cancellationToken))
            return new PaginatedResult<ReceivingInvoiceDto>
            {
                CurrentPage = command.CurrentPage,
                PageSize = command.PageSize,
                TotalResults = 0,
                Results = []
            };

        var results = await data
            .Skip(skip)
            .Take(command.PageSize)
            .Select(i => i.ToModel())
            .ToListAsync(cancellationToken);

        return new PaginatedResult<ReceivingInvoiceDto>
        {
            CurrentPage = command.CurrentPage,
            PageSize = command.PageSize,
            TotalResults = total,
            Results = results
        };
    }
}