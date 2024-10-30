using Stock.Application.Features.Commands.Items;
using Stock.Domain;
using Stock.Domain.Contracts.Items;
using Stock.Domain.Entities;

namespace Stock.Application.Contracts.Repositories;

public interface IItemRepository : IAsyncRepository<Item>
{
    Task<PaginatedResult<ItemDto>> GetItems(GetAllItemsCommand command, CancellationToken cancellationToken = default);
}