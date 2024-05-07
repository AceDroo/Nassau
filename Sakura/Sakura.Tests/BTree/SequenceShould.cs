using FluentAssertions;
using NSubstitute;
using TrenchCats.BTree;

namespace Sakura.Tests.BTree;

[TestFixture]
[TestOf(typeof(Sequence))]
[TestFixture]
public class SequenceShould
{
    [Test]
    public void Be_Created_With_A_List_Of_Nodes()
    {
        var nodes = new List<Node>();
        var sequence = new Sequence(nodes);

        sequence.Children.Should().BeEquivalentTo(nodes);
    }
    
    [Test]
    public void Evaluate_To_Failure_When_One_Node_Fails()
    {
        var nodes = new List<Node>()
        {
            CreateNodeWithState(NodeState.Failure)
        };

        var sequence = new Sequence(nodes);

        sequence.Evaluate().Should().Be(NodeState.Failure);
    }
    
    [Test]
    public void Evaluate_To_Success_When_One_Node_Succeeds()
    {
        var nodes = new List<Node>()
        {
            CreateNodeWithState(NodeState.Success)
        };

        var sequence = new Sequence(nodes);

        sequence.Evaluate().Should().Be(NodeState.Success);
    }
    
    [Test]
    public void Evaluate_To_Running_When_One_Node_Is_Running()
    {
        var nodes = new List<Node>()
        {
            CreateNodeWithState(NodeState.Running)
        };

        var sequence = new Sequence(nodes);

        sequence.Evaluate().Should().Be(NodeState.Running);
    }
    
    [Test]
    public void Evaluate_To_Running_When_One_Node_Is_Running_And_One_Node_Is_Successful()
    {
        var nodes = new List<Node>()
        {
            CreateNodeWithState(NodeState.Success),
            CreateNodeWithState(NodeState.Running)
        };

        var sequence = new Sequence(nodes);

        sequence.Evaluate().Should().Be(NodeState.Running);
    }
    
    [Test]
    public void Evaluate_To_Failure_When_One_Node_Is_Running_And_One_Node_Is_Failure()
    {
        var nodes = new List<Node>()
        {
            CreateNodeWithState(NodeState.Running),
            CreateNodeWithState(NodeState.Failure)
        };

        var sequence = new Sequence(nodes);

        sequence.Evaluate().Should().Be(NodeState.Failure);
    }
    
    [Test]
    public void Evaluate_To_Success_When_Both_Nodes_Are_Successful()
    {
        var nodes = new List<Node>()
        {
            CreateNodeWithState(NodeState.Success),
            CreateNodeWithState(NodeState.Success)
        };

        var sequence = new Sequence(nodes);

        sequence.Evaluate().Should().Be(NodeState.Success);
    }
    private Node CreateNodeWithState(NodeState state)
    {
        var node = Substitute.For<Node>();
        node.Evaluate().Returns(state);
        return node;
    }
}