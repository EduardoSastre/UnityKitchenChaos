using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class DeliveryCounter : ABaseCounter
{

    private static DeliveryCounter Instance;

    private void Awake()
    {
        Instance = this;
    }

    public override void Interact(ABaseCounter counterInteracted, Player player)
    {
       if (counterInteracted == this && player.hasKitchenObject() )
        {
            if (player.GetKitchenObject().IsThisPlateKitchenObject())
            {
                DeliveryManager.GetInstance().DeliverRecipe( player.GetKitchenObject() as PlateKitchenObject );
                KitchenObject.Destroy(player.GetKitchenObject().gameObject, player);

            }
        }
    }

    public static DeliveryCounter GetInstance() {

        return Instance;
    }

}
