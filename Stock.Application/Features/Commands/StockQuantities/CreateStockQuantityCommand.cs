using MediatR;
using Stock.Domain.Contracts.StockQuantities;

namespace Stock.Application.Features.Commands.StockQuantities;

public record CreateStockQuantityCommand(
    decimal OriginalQuantity,
    decimal ConvertedQuantity,
    string UnitType,
    int ItemId) : ICreateStockQuantityCommand, IRequest<string>;