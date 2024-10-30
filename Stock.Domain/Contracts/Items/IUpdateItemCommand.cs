namespace Stock.Domain.Contracts.Items;

public interface IUpdateItemCommand
{
    int Id { get; }
    string ItemName { get; }
    string Description { get; }
    decimal BaseUnitPrice { get; }
}