using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : ABaseCounter
{

    public override void Interact(ABaseCounter counterInteracted, Player player)
    {
       if (counterInteracted == this && player.hasKitchenObject() )
        {
            if (player.GetKitchenObject().IsThisPlateKitchenObject())
            {

                KitchenObject.Destroy(player.GetKitchenObject().gameObject, player);

            }
        }
    }

}
