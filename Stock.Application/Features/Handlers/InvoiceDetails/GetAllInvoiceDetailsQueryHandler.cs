using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.InvoiceDetails;
using Stock.Domain;
using Stock.Domain.Contracts.InvoiceDetails;

namespace Stock.Application.Features.Handlers.InvoiceDetails;

public class GetAllInvoiceDetailsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllInvoiceDetailsCommand, PaginatedResult<InvoiceDetailDto>>
{
    public async Task<PaginatedResult<InvoiceDetailDto>> Handle(GetAllInvoiceDetailsCommand command, CancellationToken cancellationToken)
        => await unitOfWork.InvoiceDetails.GetInvoiceDetailsForInvoice(command, cancellationToken);
}