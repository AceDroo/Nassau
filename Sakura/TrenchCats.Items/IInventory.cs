namespace TrenchCats.Items;

public interface IInventory
{
    IEnumerable<Item> Items { get; }
    void Add(Item item);
    void Remove(Item item);
    bool CanAdd(Item item);
    bool CanRemove(Item item);
}