using MediatR;
using Stock.Domain;
using Stock.Domain.Contracts.InvoiceDetails;
using System.ComponentModel.DataAnnotations;

namespace Stock.Application.Features.Commands.InvoiceDetails;

public record GetAllInvoiceDetailsCommand(
    string? SearchQuery,
    int InvoiceId = 0,
    [Range(1, int.MaxValue)] int CurrentPage = 1,
    [Range(1, int.MaxValue)] int PageSize = 10) : IRequest<PaginatedResult<InvoiceDetailDto>>;