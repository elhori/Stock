using MediatR;
using Stock.Domain.Contracts.StockQuantities;

namespace Stock.Application.Features.Commands.StockQuantities;

public record UpdateStockQuantityCommand(
    int Id,
    decimal OriginalQuantity,
    decimal ConvertedQuantity,
    string UnitType,
    int ItemId) : IUpdateStockQuantityCommand, IRequest<string>;