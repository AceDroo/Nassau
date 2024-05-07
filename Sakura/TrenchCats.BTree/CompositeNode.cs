namespace TrenchCats.BTree;

public abstract class CompositeNode(List<Node> children) : Node
{
    public List<Node> Children => children;
}