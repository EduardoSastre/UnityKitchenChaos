using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : ABaseCounter
{

    public event EventHandler OnPlayerGrabbedObject;

    public override void Interact(ABaseCounter counterInteracted, Player player)
    {
        bool hasObjectAbove = kitchenObjectOnPickPoint != null ? true : false;

        if (counterInteracted == this) {

            if (hasObjectAbove) {

                if (!player.hasKitchenObject())
                {
                    KitchenObject.ChangeParent(this, player);
                }         
            }
            else {

                if (!player.hasKitchenObject()) {

                    KitchenObject.Create(kitchenObjectSO.prefab, player);
                    OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
                }
                else {

                    KitchenObject.ChangeParent(player, this);
                }      
            }     
        }

    }
}
