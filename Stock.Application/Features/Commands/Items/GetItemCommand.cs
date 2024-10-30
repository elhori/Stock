using MediatR;
using Stock.Domain.Contracts.Items;

namespace Stock.Application.Features.Commands.Items;

public record GetItemCommand(int Id) : IRequest<ItemDto>;