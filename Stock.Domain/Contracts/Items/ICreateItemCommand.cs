namespace Stock.Domain.Contracts.Items;

public interface ICreateItemCommand
{
    string ItemName { get; }
    string Description { get; }
    decimal BaseUnitPrice { get; }
}