using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : ABaseCounter
{

    public event EventHandler OnPlayerGrabbedObject;

    public override void Interact(ABaseCounter counterInteracted, Player player)
    {
        bool hasObjectAbove = kitchenObject != null ? true : false;
        bool thisCounterInteract = counterInteracted == this ? true : false;

        if (thisCounterInteract)
        {
            if (hasObjectAbove) 
            {

                if (!hasGrabbedObject(player))
                {
                    KitchenObject.ChangeParent(this, player);
                }
           
            }
            else {


                if (!hasGrabbedObject(player))
                {
                    KitchenObject.Create(kitchenObjectSO.prefab, player);
                    OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
                }
                else {
                    KitchenObject.ChangeParent(player, this);
                }

                
            }     
        }

    }

    private bool hasGrabbedObject(Player player) { 
        return CheckObject.isNullOrEmpty(player.GetKitchenObject()) ? false : true;
    }
}
