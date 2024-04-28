using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : ABaseCounter
{

    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public class OnProgressChangedEventArgs : EventArgs {
        public float progressNormalized;
    }

    [SerializeField] private CuttingRecipesSO[] cuttingRecipesArraySO;
    private int cuttingProgress;

    public override void Interact(ABaseCounter counterInteracted, Player player)
    {
        if (counterInteracted == this)
        {
            if (CheckObject.isNullOrEmpty(kitchenObjectOnPickPoint) && player.hasKitchenObject())
            {
                cuttingProgress = 0;
                KitchenObject.ChangeParent(player, this);
            }
            else if (!CheckObject.isNullOrEmpty(kitchenObjectOnPickPoint) && !player.hasKitchenObject())
            {
                KitchenObject.ChangeParent(this, player);
            }
        }
    }

    public override void InteractAlternate() {
        
        if (!CheckObject.isNullOrEmpty(kitchenObjectOnPickPoint)){
            cuttingProgress++;
            cutKitchenObject(kitchenObjectOnPickPoint);
        }
    }

    private void cutKitchenObject( KitchenObject kitchenObject ) {

        KitchenObjectSO kitchenObjectCutted = null;

        foreach (CuttingRecipesSO cuttingRecipesSO in cuttingRecipesArraySO) {
            if (cuttingRecipesSO.inputObjectSO == kitchenObject.GetKitchenObjectSO()) {

                OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                {
                    progressNormalized = (float)cuttingProgress / cuttingRecipesSO.cuttingMax
                });

                if (cuttingProgress >= cuttingRecipesSO.cuttingMax)
                {
                    kitchenObjectCutted = cuttingRecipesSO.outputObjectSO;
                }
            }
        }

        if (!CheckObject.isNullOrEmpty(kitchenObjectCutted)) {
            KitchenObject.Destroy(kitchenObject.gameObject, this);
            KitchenObject.Create(kitchenObjectCutted.prefab, this);
        }
        
    }

}
