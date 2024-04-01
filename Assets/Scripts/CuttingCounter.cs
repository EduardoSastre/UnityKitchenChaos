using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : ABaseCounter
{
    [SerializeField] CuttingRecipesSO[] cuttingRecipesArraySO;

    public override void Interact(ABaseCounter counterInteracted, Player player)
    {
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

    public override void InteractAlternate() {
        
        if (!CheckObject.isNullOrEmpty(kitchenObject)){
            cutKitchenObject(kitchenObject);
        }
    }

    private void cutKitchenObject( KitchenObject kitchenObject ) {

        KitchenObjectSO kitchenObjectCutted = null;

        foreach (CuttingRecipesSO cuttingRecipesSO in cuttingRecipesArraySO) {
            if (cuttingRecipesSO.inputObjectSO == kitchenObject.GetKitchenObjectSO()) {
                kitchenObjectCutted = cuttingRecipesSO.outputObjectSO;
            }
        }

        if (!CheckObject.isNullOrEmpty(kitchenObjectCutted)) {
            Debug.Log("Old kitchen Object: " + kitchenObject.name );
            KitchenObject.Destroy(kitchenObject.gameObject, this);
            KitchenObject.Create(kitchenObjectCutted.prefab, this);
            Debug.Log("New kitchen Object: " + kitchenObject.name);
        }
        
    }
}
