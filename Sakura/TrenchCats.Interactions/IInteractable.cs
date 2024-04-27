namespace TrenchCats.Interactions;

public interface IInteractable
{
    bool TryInteract(IInteractableActor actor);
}