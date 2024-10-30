using MediatR;
using Stock.Domain.Contracts.Items;

namespace Stock.Application.Features.Commands.Items;

public record UpdateItemCommand(
    int Id,
    string ItemName,
    string Description,
    decimal BaseUnitPrice) : IUpdateItemCommand, IRequest<string>;