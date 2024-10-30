using MediatR;

namespace Stock.Application.Features.Commands.Items;

public record DeleteItemCommand(int Id) : IRequest<string>;