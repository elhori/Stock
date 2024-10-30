using System.ComponentModel.DataAnnotations.Schema;
using Stock.Domain.Contracts.InvoiceDetails;

namespace Stock.Domain.Entities;

public class InvoiceDetail
{
    private InvoiceDetail() { }

    public InvoiceDetail(ICreateInvoiceDetailCommand model)
    {
        QuantityReceived = model.QuantityReceived;
        UnitPrice = model.UnitPrice;
        InvoiceId = model.InvoiceId;
        ItemId = model.ItemId;
    }

    /// <summary>
    /// معرف تفاصيل الفاتورة: رقم فريد لتعريف تفاصيل الفاتورة.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// الكمية المستلمة: الكمية المستلمة من الصنف.
    /// </summary>
    [Column(TypeName = "decimal(18, 2)")]
    public decimal QuantityReceived { get; private set; }

    /// <summary>
    /// سعر الوحدة: السعر لكل وحدة من الصنف.
    /// </summary>
    [Column(TypeName = "decimal(18, 3)")]
    public decimal UnitPrice { get; private set; }

    /// <summary>
    /// معرف الفاتورة: رقم الفاتورة المرتبطة بهذه التفاصيل.
    /// </summary>
    public int InvoiceId { get; private set; }

    public ReceivingInvoice Invoice { get; private set; } = default!;

    /// <summary>
    /// معرف الصنف: يشير إلى الصنف المرتبط بالتفاصيل.
    /// </summary>
    public int ItemId { get; private set; }

    public Item Item { get; private set; } = default!;

    public void Update(IUpdateInvoiceDetailCommand model)
    {
        QuantityReceived = model.QuantityReceived;
        UnitPrice = model.UnitPrice;
        InvoiceId = model.InvoiceId;
        ItemId = model.ItemId;
    }

    public InvoiceDetailDto ToModel()
        => new(Id, QuantityReceived, UnitPrice, InvoiceId, ItemId, Item.ItemName);
}