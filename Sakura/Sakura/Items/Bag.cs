namespace Sakura.Items;

public class Bag : Item, IInventory
{
    private readonly List<Item> _items;
    private readonly int _capacity;

    public Bag(int capacity)
    {
        _capacity = capacity;
        _items = [];
    }

    public IEnumerable<Item> Items => _items;

    public void Add(Item item)
    {
        _items.Add(item);
    }

    public void Remove(Item item)
    {
        _items.Remove(item);
    }

    public bool CanAdd(Item item)
    {
        return _items.Count < _capacity && item is not IInventory;
    }

    public bool CanRemove(Item item)
    {
        return _items.Count > 0;
    }
}