using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : ABaseCounter
{

    public override void CancelInteract()
    {
        VisualCounterBehaviour.CancelVisualInteraction(this);
    }

    public override void Interact(AInteractable player) {

        if ( CheckObject.isNullOrEmpty(kitchenObject) && player.hasKitchenObject() ) 
        {    
            KitchenObject.ChangeParent( player.GetKitchenObject() , player, this );     
        }
        else if (!CheckObject.isNullOrEmpty(kitchenObject) && !player.hasKitchenObject())
        {
            KitchenObject.ChangeParent(this.GetKitchenObject(), this, player);
        }


    }
}
