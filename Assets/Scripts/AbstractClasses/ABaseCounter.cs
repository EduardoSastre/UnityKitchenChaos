using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABaseCounter : AInteractable
{

    [SerializeField] protected KitchenObjectSO kitchenObjectSO;

    public void Start()
    {
        SetPickPoint();
        Player.GetInstance().OnCounterInteraction += ABaseCounter_OnCounterInteraction;
    }

    private void ABaseCounter_OnCounterInteraction(object sender, Player.OnCounterInteractionEventsArgs interactedObjects)
    {
        Interact(interactedObjects.counter, interactedObjects.player);
    }

    public abstract void Interact( ABaseCounter counterInteracted, Player player );

    public virtual void InteractAlternate() { 
        //TODO: FUTURE IMPLEMENTATION
    }

}
