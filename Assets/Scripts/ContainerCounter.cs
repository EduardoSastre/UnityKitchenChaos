using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : ABaseCounter
{
    public override void CancelInteract()
    {
        VisualCounterBehaviour.CancelVisualInteraction(this);
    }

    public override void Interact(AInteractable player)
    {

        if (kitchenObject == null && !CheckObject.isNullOrEmpty(kitchenObjectSO.prefab))
        {
            kitchenObject = KitchenObject.Create(kitchenObjectSO.prefab, pickPoint);
        }
        else if (kitchenObject != null)
        {
            KitchenObject.ChangeParent( kitchenObject, this, player );
        }


    }
}
