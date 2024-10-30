using Microsoft.EntityFrameworkCore;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.InvoiceDetails;
using Stock.Domain;
using Stock.Domain.Contracts.InvoiceDetails;
using Stock.Domain.Entities;

namespace Stock.Infrastructure.Persistence.Repositories;

public class InvoiceDetailRepository(AppDbContext context) : AsyncRepository<InvoiceDetail>(context), IInvoiceDetailRepository
{
    public async Task<PaginatedResult<InvoiceDetailDto>> GetInvoiceDetailsForInvoice(GetAllInvoiceDetailsCommand command, CancellationToken cancellationToken = default)
    {
        var data = context.InvoiceDetails
            .Where(i => command.InvoiceId > 0 ? i.InvoiceId == command.InvoiceId : true)
            .Include(i => i.Item)
            .AsNoTracking();

        if (!string.IsNullOrEmpty(command.SearchQuery))
            data = data.Where(i => i.Item.ItemName.Trim().ToUpper() == command.SearchQuery.Trim().ToUpper());

        var total = await data.CountAsync(cancellationToken);

        var skip = command.PageSize * (command.CurrentPage - 1);

        if (!await data.Skip(skip).AnyAsync(cancellationToken: cancellationToken))
            return new PaginatedResult<InvoiceDetailDto>
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

        return new PaginatedResult<InvoiceDetailDto>
        {
            CurrentPage = command.CurrentPage,
            PageSize = command.PageSize,
            TotalResults = total,
            Results = results
        };
    }
}