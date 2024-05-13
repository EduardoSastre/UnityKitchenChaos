using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : ABaseCounter, IHasProgress
{

    [SerializeField] private CuttingRecipesSO[] cuttingRecipesArraySO;
    private int cuttingProgress;

    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
    public static event EventHandler OnAnyCut;

    public override void Interact(ABaseCounter counterInteracted, Player player)
    {
        if (counterInteracted == this)
        {
            if (!this.hasKitchenObject() && player.hasKitchenObject())
            {
                cuttingProgress = 0;
            }
        }

        base.Interact(counterInteracted, player);
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

                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                {
                    progressNormalized = (float)cuttingProgress / cuttingRecipesSO.cuttingMax
                });
                OnAnyCut?.Invoke(this, EventArgs.Empty);

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
