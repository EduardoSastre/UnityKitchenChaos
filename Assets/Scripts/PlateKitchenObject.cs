using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> kitchenObjectSOAllowedList;
    private List<KitchenObjectSO> kitchenObjectSOList;

    public event EventHandler<OnAddedIngredientEventArgs> OnAddedIngredient;

    public class OnAddedIngredientEventArgs : EventArgs { 
        
        public KitchenObjectSO kitchenObjectSO;

    }

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public void TryAddKitchenObjectSO( KitchenObject kitchenObject, AInteractable interactable ) {

        bool existOnList = kitchenObjectSOList.Contains(kitchenObject.GetKitchenObjectSO());
        bool canBeOnList = kitchenObjectSOAllowedList.Contains(kitchenObject.GetKitchenObjectSO());

        if (!existOnList && canBeOnList) {

            kitchenObjectSOList.Add(kitchenObject.GetKitchenObjectSO());

            OnAddedIngredient?.Invoke( this, new OnAddedIngredientEventArgs { 
                kitchenObjectSO = kitchenObject.GetKitchenObjectSO()
            });

            KitchenObject.Destroy( kitchenObject.gameObject , interactable);
        }
    }

    public List<KitchenObjectSO> GetRecipe() { 
        return kitchenObjectSOList;
    }
}
