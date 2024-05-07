namespace TrenchCats.BTree;

public class Sequence(List<Node> children) : CompositeNode(children)
{
    public override NodeState Evaluate()
    {
        var isAnyNodeRunning = false;
            
        foreach (var node in Children)
        {
            switch (node.Evaluate())
            {
                case NodeState.Failure:
                    return NodeState.Failure;
                case NodeState.Success:
                    continue;
                case NodeState.Running:
                    isAnyNodeRunning = true;
                    break;
                default:
                    return NodeState.Success;
            }
        }
        return isAnyNodeRunning ? NodeState.Running : NodeState.Success;
    }
}