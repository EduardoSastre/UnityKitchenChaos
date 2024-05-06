using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private GameObject iconTemplate;

    private void Start()
    {
        plateKitchenObject.OnAddedIngredient += PlateKitchenObject_OnAddedIngredient;
    }

    private void PlateKitchenObject_OnAddedIngredient(object sender, PlateKitchenObject.OnAddedIngredientEventArgs ingredient)
    {
        UpdateVisual( ingredient.kitchenObjectSO );
    }

    private void UpdateVisual( KitchenObjectSO kitchenObjectSO ) {

        GameObject newIconTemplate = Instantiate( iconTemplate, this.transform );
        PlateIconSingleUI templateIcon = newIconTemplate.GetComponent<PlateIconSingleUI>();
        templateIcon.SetImage(kitchenObjectSO);
    }
}
