using MediatR;

namespace Stock.Application.Features.Commands.StockQuantities;

public record DeleteStockQuantityCommand(int Id) : IRequest<string>;