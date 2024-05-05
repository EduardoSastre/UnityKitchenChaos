using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : ABaseCounter
{

    public event EventHandler OnPlayerGrabbedObject;

    public override void Interact(ABaseCounter counterInteracted, Player player)
    {

        base.Interact(counterInteracted, player);

        if (counterInteracted == this) {

            if (!this.hasKitchenObject()) {

                if (!player.hasKitchenObject()) {

                    KitchenObject.Create(kitchenObjectSO.prefab, player);
                    OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
                }    
            }     
        }

    }
}
