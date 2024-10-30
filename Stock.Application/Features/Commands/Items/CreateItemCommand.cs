using MediatR;
using Stock.Domain.Contracts.Items;

namespace Stock.Application.Features.Commands.Items;

public record CreateItemCommand(
    string ItemName,
    string Description,
    decimal BaseUnitPrice) : ICreateItemCommand, IRequest<string>;