using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Domain.Contracts.ReceivingInvoices;

namespace Stock.Domain.Entities;

public class ReceivingInvoice
{
    private ReceivingInvoice() { }

    public ReceivingInvoice(ICreateReceivingInvoiceCommand model)
    {
        ReceivingDate = model.ReceivingDate;
        Supplier = model.Supplier;
        TotalAmount = model.TotalAmount;
    }

    /// <summary>
    /// معرف الفاتورة: رقم فريد لتعريف فاتورة الاستلام.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// تاريخ الاستلام: تاريخ إصدار الفاتورة.
    /// </summary>
    public DateTime ReceivingDate { get; private set; }

    /// <summary>
    /// المورد: اسم المورد أو الشركة الموردة.
    /// </summary>
    public string Supplier { get; private set; } = string.Empty;

    /// <summary>
    /// إجمالي المبلغ: المبلغ الإجمالي للفاتورة.
    /// </summary>
    [Column(TypeName = "decimal(18, 3)")]
    public decimal TotalAmount { get; private set; }

    private readonly HashSet<InvoiceDetail> _invoiceDetails = new();
    public IReadOnlyCollection<InvoiceDetail> InvoiceDetails => _invoiceDetails;

    public void Update(IUpdateReceivingInvoiceCommand model)
    {
        ReceivingDate = model.ReceivingDate;
        Supplier = model.Supplier;
        TotalAmount = model.TotalAmount;
    }

    public ReceivingInvoiceDto ToModel()
        => new(
            Id, 
            ReceivingDate, 
            Supplier, 
            TotalAmount, 
            InvoiceDetails.Select(i => i.ToModel()).ToList());
}