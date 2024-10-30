namespace Stock.Application.Contracts.Repositories;

public interface IUnitOfWork : IDisposable
{
    IInvoiceDetailRepository InvoiceDetails { get; }
    IItemRepository Items { get; }
    IReceivingInvoiceRepository ReceivingInvoices { get; }
    IStockQuantityRepository StockQuantities { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}