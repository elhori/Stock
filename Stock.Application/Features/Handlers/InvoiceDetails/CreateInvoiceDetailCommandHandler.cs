using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Stock.Application.Contracts.Repositories;
using Stock.Application.Features.Commands.InvoiceDetails;
using Stock.Application.Resources;
using Stock.Domain.Entities;

namespace Stock.Application.Features.Handlers.InvoiceDetails;

public class CreateInvoiceDetailCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateInvoiceDetailCommand, string>
{
    public async Task<string> Handle(CreateInvoiceDetailCommand command, CancellationToken cancellationToken)
    {
        if (await unitOfWork.InvoiceDetails.AnyAsync(
                i => i.ItemId == command.ItemId && i.InvoiceId == command.InvoiceId, cancellationToken))
            return ResponseMessages.AlreadyExists;

        var invoiceDetail = new InvoiceDetail(command);

        await unitOfWork.InvoiceDetails.AddAsync(invoiceDetail, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return ResponseMessages.Added;
    }
}