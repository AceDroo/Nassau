namespace TrenchCats.BTree;

public class Inverter(Node child) : Node
{
    public Node Child => child;
    
    public override NodeState Evaluate()
    {
        return child.Evaluate() switch
        {
            NodeState.Running => NodeState.Running,
            NodeState.Failure => NodeState.Success,
            NodeState.Success => NodeState.Failure,
            _ => NodeState.Running
        };
    }
}