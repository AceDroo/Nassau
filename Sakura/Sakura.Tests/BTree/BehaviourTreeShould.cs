using FluentAssertions;
using NSubstitute;
using TrenchCats.BTree;

namespace Sakura.Tests.BTree;

[TestFixture]
[TestOf(typeof(BehaviourTree))]
public class BehaviourTreeShould
{
    [Test]
    public void Be_Initialized_With_Root_Node()
    {
        var node = Substitute.For<Node>();
        var tree = new BehaviourTree(node);

        tree.Root.Should().Be(node);
    }
    
    [Test]
    public void Evaluate_Root_Node_Every_Tick()
    {
        var node = Substitute.For<Node>();
        node.Evaluate().Returns(NodeState.Running);
        var tree = new BehaviourTree(node);

        tree.Tick(1.0f);

        node.Received().Evaluate();
    }
    
}