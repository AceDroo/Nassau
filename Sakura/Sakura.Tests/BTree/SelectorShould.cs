using FluentAssertions;
using NSubstitute;
using TrenchCats.BTree;

namespace Sakura.Tests.BTree;

[TestFixture]
public class SelectorShould
{
    [Test]
    public void Be_Created_With_A_List_Of_Nodes()
    {
        var nodes = new List<Node>();
        var selector = new Selector(nodes);

        selector.Children.Should().BeEquivalentTo(nodes);
    }

    [Test]
    public void Evaluate_To_Running_When_One_Node_Is_Running()
    {
        var nodes = new List<Node> { CreateNodeWithState(NodeState.Running) };

        var selector = new Selector(nodes);

        selector.Evaluate().Should().Be(NodeState.Running);
    }

    [Test]
    public void Evaluate_To_Success_When_One_Node_Is_Successful()
    {
        var nodes = new List<Node> { CreateNodeWithState(NodeState.Success) };

        var selector = new Selector(nodes);

        selector.Evaluate().Should().Be(NodeState.Success);
    }
    
    [Test]
    public void Evaluate_To_Failure_When_One_Node_Fails()
    {
        var nodes = new List<Node> { CreateNodeWithState(NodeState.Failure) };

        var selector = new Selector(nodes);

        selector.Evaluate().Should().Be(NodeState.Failure);
    }

    [Test]
    public void Evaluate_To_Success_When_One_Success_And_One_Running()
    {
        var nodes = new List<Node>
        {
            CreateNodeWithState(NodeState.Success),
            CreateNodeWithState(NodeState.Running)
        };

        var selector = new Selector(nodes);

        selector.Evaluate().Should().Be(NodeState.Success);
    }

    [Test]
    public void Evaluate_To_Running_When_One_Running_And_One_Success()
    {
        var nodes = new List<Node>
        {
            CreateNodeWithState(NodeState.Running),
            CreateNodeWithState(NodeState.Success)
        };

        var selector = new Selector(nodes);

        selector.Evaluate().Should().Be(NodeState.Running);
    }
    
    [Test]
    public void Evaluate_To_Running_When_One_Failure_And_One_Running()
    {
        var nodes = new List<Node>
        {
            CreateNodeWithState(NodeState.Failure),
            CreateNodeWithState(NodeState.Running)
        };

        var selector = new Selector(nodes);

        selector.Evaluate().Should().Be(NodeState.Running);
    }
    
    [Test]
    public void Evaluate_To_Success_When_One_Failure_And_One_Success()
    { 
        var nodes = new List<Node>
        {
            CreateNodeWithState(NodeState.Failure),
            CreateNodeWithState(NodeState.Success)
        };

        var selector = new Selector(nodes);

        selector.Evaluate().Should().Be(NodeState.Success);
    }
    
    [Test]
    public void Evaluate_To_Failure_When_Multiple_Failures()
    {
        var nodes = new List<Node>
        {
            CreateNodeWithState(NodeState.Failure),
            CreateNodeWithState(NodeState.Failure)
        };

        var selector = new Selector(nodes);

        selector.Evaluate().Should().Be(NodeState.Failure);
    }

    private Node CreateNodeWithState(NodeState state)
    {
        var node = Substitute.For<Node>();
        node.Evaluate().Returns(state);
        return node;
    }
}