using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Application.Contracts.Repositories;

namespace Stock.Infrastructure.Persistence.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private IInvoiceDetailRepository _invoiceDetails;

    public IInvoiceDetailRepository InvoiceDetails
    {
        get
        {
            return _invoiceDetails ??= new InvoiceDetailRepository(context);
        }
    }

    private IItemRepository _items;
    public IItemRepository Items
    {
        get
        {
            return _items ??= new ItemRepository(context);
        }
    }

    private IReceivingInvoiceRepository _receivingInvoices;
    public IReceivingInvoiceRepository ReceivingInvoices
    {
        get
        {
            return _receivingInvoices ??= new ReceivingInvoiceRepository(context);
        }
    }

    private IStockQuantityRepository _stockQuantities;
    public IStockQuantityRepository StockQuantities
    {
        get
        {
            return _stockQuantities ??= new StockQuantityRepository(context);
        }
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        context.Dispose();
    }
}