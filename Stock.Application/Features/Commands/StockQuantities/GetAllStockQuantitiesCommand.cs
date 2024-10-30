using System.ComponentModel.DataAnnotations;
using MediatR;
using Stock.Domain;
using Stock.Domain.Contracts.StockQuantities;

namespace Stock.Application.Features.Commands.StockQuantities;

public record GetAllStockQuantitiesCommand(
    string? SearchQuery,
    [Range(1, int.MaxValue)] int CurrentPage = 1,
    [Range(1, int.MaxValue)] int PageSize = 10) : IRequest<PaginatedResult<StockQuantityDto>>;