using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : ABaseCounter
{
    public override void Interact(ABaseCounter counterInteracted, Player player) {

        if (counterInteracted == this)
        {
            if (CheckObject.isNullOrEmpty(kitchenObject) && player.hasKitchenObject())
            {
                KitchenObject.ChangeParent(player, this);
            }
            else if (!CheckObject.isNullOrEmpty(kitchenObject) && !player.hasKitchenObject())
            {
                KitchenObject.ChangeParent(this, player);
            }
        }

    }
}
