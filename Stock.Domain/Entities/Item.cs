using Stock.Domain.Contracts.Items;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock.Domain.Entities;

public class Item
{
    private Item() { }

    public Item(ICreateItemCommand model)
    {
        ItemName = model.ItemName;
        Description = model.Description;
        BaseUnitPrice = model.BaseUnitPrice;
    }

    /// <summary>
    /// معرف الصنف: رقم فريد لتعريف الصنف.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// اسم الصنف: اسم الصنف أو المنتج.
    /// </summary>
    public string ItemName { get; private set; } = string.Empty;

    /// <summary>
    /// الوصف: وصف إضافي للصنف.
    /// </summary>
    public string Description { get; private set; } = string.Empty;

    /// <summary>
    /// سعر الوحدة الأساسية: السعر الأساسي للوحدة.
    /// </summary>
    [Column(TypeName = "decimal(18, 3)")]
    public decimal BaseUnitPrice { get; private set; }

    public void Update(IUpdateItemCommand model)
    {
        ItemName = model.ItemName;
        Description = model.Description;
        BaseUnitPrice = model.BaseUnitPrice;
    }

    public ItemDto ToModel()
        => new(Id, ItemName, Description, BaseUnitPrice);
}