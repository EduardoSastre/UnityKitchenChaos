using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryManagerSingleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private Transform iconContainer;
    [SerializeField] private Transform iconTemplate;

    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }

    public void SetRecipeText( RecipeSO recipeSO ) {
        recipeNameText.text = recipeSO.name;
    }

    public void SetIcons( RecipeSO recipeSO ) { 
        
        foreach (Transform iconTemplate in iconContainer)
        {
            if (iconTemplate == this.iconTemplate) {
                continue;
            }

            Destroy(iconTemplate.gameObject);
        }

        foreach (KitchenObjectSO kitchenObjectSO in recipeSO.kitchenObjectSOList )
        {
            Transform icon = Instantiate(iconTemplate, iconContainer);
            icon.GetComponent<Image>().sprite = kitchenObjectSO.sprite;
            icon.gameObject.SetActive(true);

        }

    }
}
