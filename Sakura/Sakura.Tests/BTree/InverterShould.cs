using FluentAssertions;
using NSubstitute;
using TrenchCats.BTree;

namespace Sakura.Tests.BTree;

[TestFixture]
[TestOf(typeof(Inverter))]
public class InverterShould
{
    [Test]
    public void Be_Created_With_One_Node()
    {
        var node = Substitute.For<Node>();
        var inverter = new Inverter(node);

        inverter.Child.Should().Be(node);
    }

    [Test]
    public void Evaluate_To_Running_If_Node_Is_Running()
    {
        var node = Substitute.For<Node>();
        node.Evaluate().Returns(NodeState.Running);

        var inverter = new Inverter(node);

        inverter.Evaluate().Should().Be(NodeState.Running);
    }
        
    [Test]
    public void Evaluate_To_Failure_If_Node_Is_Successful()
    {
        var node = Substitute.For<Node>();
        node.Evaluate().Returns(NodeState.Success);

        var inverter = new Inverter(node);

        inverter.Evaluate().Should().Be(NodeState.Failure);
    }
        
    [Test]
    public void Evaluate_To_Success_If_Node_Fails()
    {
        var node = Substitute.For<Node>();
        node.Evaluate().Returns(NodeState.Failure);

        var inverter = new Inverter(node);

        inverter.Evaluate().Should().Be(NodeState.Success);
    }
}