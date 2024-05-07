namespace TrenchCats.BTree;

public class Selector(List<Node> children) : CompositeNode(children)
{
    public override NodeState Evaluate()
    {
        foreach (var child in Children)
        {
            switch (child.Evaluate())
            {
                case NodeState.Failure:
                    continue;
                case NodeState.Running:
                    return NodeState.Running;
                case NodeState.Success:
                    return NodeState.Success;
                default:
                    continue;
            }
        }
        return NodeState.Failure;
    }
}