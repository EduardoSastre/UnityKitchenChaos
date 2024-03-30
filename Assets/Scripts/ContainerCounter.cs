using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : ABaseCounter
{

    public event EventHandler OnPlayerGrabbedObject;

    public override void CancelInteract()
    {
        //VisualCounterBehaviour.CancelVisualInteraction(this);
    }

    public override void Interact(AInteractable player)
    {
        bool hasCounterObjectAbove = kitchenObject != null ? true : false;

        if ( !hasCounterObjectAbove && !CheckObject.isNullOrEmpty(kitchenObjectSO.prefab))
        {
            if (!hasGrabbedObject(player))
            {
                KitchenObject.Create(kitchenObjectSO.prefab, player);
                OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
            }
            else {
                KitchenObject.ChangeParent( player, this);
            }         
        }
        else if (hasCounterObjectAbove)
        {
            if (!hasGrabbedObject(player))
            {
                KitchenObject.ChangeParent(this, player);
            }
        }


    }

    private bool hasGrabbedObject(AInteractable player) { 
        return CheckObject.isNullOrEmpty(player.GetKitchenObject()) ? false : true;
    }
}
