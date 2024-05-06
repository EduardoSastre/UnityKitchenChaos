using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObjectSO_GameObject> kitchenObjectSOGameObjectsList;

    [Serializable]
    public struct KitchenObjectSO_GameObject {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    private void Start()
    {
        plateKitchenObject.OnAddedIngredient += PlateKitchenObject_OnAddedIngredient;
    }

    private void PlateKitchenObject_OnAddedIngredient(object sender, PlateKitchenObject.OnAddedIngredientEventArgs ingredient)
    {
        foreach ( KitchenObjectSO_GameObject kitchenObjectSO_GameObject in kitchenObjectSOGameObjectsList ) {

            if (kitchenObjectSO_GameObject.kitchenObjectSO == ingredient.kitchenObjectSO ) {

                kitchenObjectSO_GameObject.gameObject.SetActive(true);
            }
        
        }
    }
}
