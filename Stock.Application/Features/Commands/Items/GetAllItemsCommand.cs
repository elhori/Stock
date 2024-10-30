using MediatR;
using Stock.Domain;
using Stock.Domain.Contracts.Items;
using System.ComponentModel.DataAnnotations;

namespace Stock.Application.Features.Commands.Items;

public record GetAllItemsCommand(
    string? SearchQuery,
    [Range(1, int.MaxValue)] int CurrentPage = 1,
    [Range(1, int.MaxValue)] int PageSize = 10) : IRequest<PaginatedResult<ItemDto>>;