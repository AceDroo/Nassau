namespace TrenchCats.BTree;

public class BehaviourTree(Node root)
{
    public Node Root => root;

    public void Tick(double deltaTime)
    {
        root.Evaluate();
    }
}