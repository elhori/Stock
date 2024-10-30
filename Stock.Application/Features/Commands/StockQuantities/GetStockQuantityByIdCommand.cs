using MediatR;
using Stock.Domain.Contracts.StockQuantities;

namespace Stock.Application.Features.Commands.StockQuantities;

public record GetStockQuantityByIdCommand(int Id) : IRequest<StockQuantityDto>;