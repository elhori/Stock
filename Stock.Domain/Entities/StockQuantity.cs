using Stock.Domain.Contracts.StockQuantities;
using Stock.Domain.Enums;
using Stock.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock.Domain.Entities;

public class StockQuantity
{
    private StockQuantity() { }

    public StockQuantity(ICreateStockQuantityCommand model)
    {
        OriginalQuantity = model.OriginalQuantity;
        ConvertedQuantity = model.ConvertedQuantity;
        UnitType = Enum.Parse<UnitType>(model.UnitType);
        ItemId = model.ItemId;
    }

    /// <summary>
    /// معرف تحويل الكمية: رقم فريد لتعريف عملية تحويل الكمية.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// الكمية الأصلية: الكمية قبل التحويل.
    /// </summary>
    [Column(TypeName = "decimal(18, 2)")]
    public decimal OriginalQuantity { get; private set; }

    /// <summary>
    /// الكمية المحولة: الكمية بعد التحويل.
    /// </summary>
    [Column(TypeName = "decimal(18, 2)")]
    public decimal ConvertedQuantity { get; private set; }

    /// <summary>
    /// نوع الوحدة: نوع الوحدة المستخدمة في التحويل (مثل جرام أو كيلوغرام).
    /// </summary>
    public UnitType UnitType { get; private set; }

    /// <summary>
    /// معرف الصنف: يشير إلى الصنف المرتبط بتحويل الكمية.
    /// </summary>
    public int ItemId { get; private set; }

    public Item Item { get; private set; } = default!;

    public void Update(IUpdateStockQuantityCommand model)
    {
        OriginalQuantity = model.OriginalQuantity;
        ConvertedQuantity = model.ConvertedQuantity;
        UnitType = Enum.Parse<UnitType>(model.UnitType);
        ItemId = model.ItemId;
    }

    public StockQuantityDto ToModel()
        => new(Id, OriginalQuantity, ConvertedQuantity, UnitType.GetDisplayName(), ItemId, Item.ItemName);
}