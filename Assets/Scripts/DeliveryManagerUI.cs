using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private Transform ContainerRecipesTemplate;
    [SerializeField] private Transform recipeTemplate;

    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        DeliveryManager.GetInstance().OnRecipeAdded += DeliveryManagerUI_OnRecipeAdded;
        DeliveryManager.GetInstance().OnRecipeDelivery += DeliveryManagerUI_OnRecipeDelivery;

        UpdateVisuals();
    }

    private void DeliveryManagerUI_OnRecipeAdded(object sender, System.EventArgs e)
    {
        UpdateVisuals();
    }

    private void DeliveryManagerUI_OnRecipeDelivery(object sender, System.EventArgs e)
    {
        UpdateVisuals();
    }

    private void UpdateVisuals() {
        foreach (Transform recipeWaiting in ContainerRecipesTemplate) { 
            
            if (recipeWaiting == recipeTemplate)
            {
                continue;
            }

            Destroy(recipeWaiting.gameObject);
        }



        foreach ( RecipeSO recipeWaiting in DeliveryManager.GetInstance().GetWaitingRecipesList()) {

            Transform recipeTemplateSpawned = Instantiate(recipeTemplate, ContainerRecipesTemplate);
            
            recipeTemplateSpawned.GetComponent<DeliveryManagerSingleUI>().SetRecipeText(recipeWaiting);
            recipeTemplateSpawned.GetComponent<DeliveryManagerSingleUI>().SetIcons(recipeWaiting);
            recipeTemplateSpawned.gameObject.SetActive(true);



        }
    }
}
