using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : ABaseCounter
{
    public override void Interact(ABaseCounter counterInteracted, Player player)
    {
        if (counterInteracted == this && player.hasKitchenObject()) {

            KitchenObject.ChangeParent(player, this);
            KitchenObject.Destroy(this.GetKitchenObject().gameObject, this);
        }
    }
}
