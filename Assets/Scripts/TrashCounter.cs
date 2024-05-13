using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : ABaseCounter
{
    public static event EventHandler OnDestroying;

    public override void Interact(ABaseCounter counterInteracted, Player player)
    {
        if (counterInteracted == this && player.hasKitchenObject()) {

            KitchenObject.Destroy(player.GetKitchenObject().gameObject, player);
            OnDestroying?.Invoke(this, EventArgs.Empty);
        }
    }
}
