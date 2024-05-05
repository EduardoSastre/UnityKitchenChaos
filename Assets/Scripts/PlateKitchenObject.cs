using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> kitchenObjectSOAllowedList;
    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public void TryAddKitchenObjectSO( KitchenObject kitchenObject, AInteractable interactable ) {

        bool existOnList = kitchenObjectSOList.Contains(kitchenObject.GetKitchenObjectSO());
        bool canBeOnList = kitchenObjectSOAllowedList.Contains(kitchenObject.GetKitchenObjectSO());

        if (!existOnList && canBeOnList) {

            kitchenObjectSOList.Add(kitchenObject.GetKitchenObjectSO());
            KitchenObject.Destroy( kitchenObject.gameObject , interactable);
        }
    }
}
