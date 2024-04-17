using FluentAssertions;
using Sakura.Items;

namespace Sakura.Tests.Items;

[TestFixture]
public class BagShould
{
    [Test]
    public void Start_With_No_Items()
    {
        var bag = new Bag(10);

        bag.Items.Should().BeEmpty();
    }

    [Test]
    public void Add_Item()
    {
        var bag = new Bag(10);

        var item = new Item();
        bag.Add(item);

        bag.Items.Should().Contain(item);
    }

    [Test]
    public void Remove_Item()
    {
        var bag = new Bag(10);

        var item = new Item();
        bag.Add(item);
        bag.Remove(item);

        bag.Items.Should().BeEmpty();
    }

    [Test]
    public void Add_Multiple_Items()
    {
        var bag = new Bag(10);

        var item1 = new Item();
        var item2 = new Item();
        var item3 = new Item();

        bag.Add(item1);
        bag.Add(item3);
        bag.Add(item2);

        bag.Items.Should().ContainInOrder(item1, item3, item2);
    }

    [Test]
    public void Remove_Multiple_Items()
    {
        var bag = new Bag(10);

        var item1 = new Item();
        var item2 = new Item();
        var item3 = new Item();

        bag.Add(item1);
        bag.Add(item3);
        bag.Add(item2);
        bag.Remove(item3);
        bag.Remove(item1);

        bag.Items.Should().ContainInOrder(item2);
    }

    [Test]
    public void Return_True_When_CanAdd_Item()
    {
        var bag = new Bag(1);

        bag.CanAdd(new Item()).Should().BeTrue();
    }

    [Test]
    public void Return_False_When_Adding_Item_But_Exceeds_Capacity()
    {
        var bag = new Bag(1);
        bag.Add(new Item());

        bag.CanAdd(new Item()).Should().BeFalse();
    }

    [Test]
    public void Return_False_When_CannotAdd_Item_With_Inventory()
    {
        var bag = new Bag(10);

        bag.CanAdd(new Bag(1)).Should().BeFalse();
    }

    [Test]
    public void Return_True_When_CanRemove_Item()
    {
        var bag = new Bag(1);

        bag.Add(new Item());

        bag.CanRemove(new Item()).Should().BeTrue();
    }

    [Test]
    public void Return_False_When_CannotRemove_Item()
    {
        var bag = new Bag(1);

        bag.CanRemove(new Item()).Should().BeFalse();
    }
}