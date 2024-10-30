using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.ReceivingInvoices;
using Stock.Domain;
using Stock.Domain.Contracts.ReceivingInvoices;

namespace Stock.Application.Features.Handlers.ReceivingInvoices;

public class GetAllReceivingInvoicesCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllReceivingInvoicesCommand, PaginatedResult<ReceivingInvoiceDto>>
{
    public async Task<PaginatedResult<ReceivingInvoiceDto>> Handle(GetAllReceivingInvoicesCommand command, CancellationToken cancellationToken)
        => await unitOfWork.ReceivingInvoices.GetReceivingInvoices(command, cancellationToken: cancellationToken);
}