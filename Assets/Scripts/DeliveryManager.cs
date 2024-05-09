using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private RecipeListSO allRecipesList;
    private List<RecipeSO> waitingRecipesList;
    private int recipesAcumulated = 0;
    private int MaxRecipesAcumulated = 4;
    private float timer = 0;
    private float timerMax = 4;

    private static DeliveryManager instance;

    private void Awake()
    {
        instance = this;
        waitingRecipesList = new List<RecipeSO>(4);
    }

    public void Update()
    {
        AddRandomRecipe();
    }

    private void AddRandomRecipe() {

        if (recipesAcumulated < MaxRecipesAcumulated) {

            timer += Time.deltaTime;

            if (timer >= timerMax) {
                RecipeSO randomRecipe = allRecipesList.recipeSOList[Random.Range(0, allRecipesList.recipeSOList.Count)];

                waitingRecipesList.Add(randomRecipe);
                timer = 0;
                recipesAcumulated++;
            }    
        }
        

    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject ) {

        bool isAValidRecipe = false;

        for ( int i=0; i < waitingRecipesList.Count; i++) {

            RecipeSO recipeWaiting = waitingRecipesList[i];

            foreach ( KitchenObjectSO kitchenObjectSO in recipeWaiting.kitchenObjectSOList ) {

                if (!plateKitchenObject.GetRecipe().Contains(kitchenObjectSO)) {

                    isAValidRecipe = false;
                    break;
                }

                isAValidRecipe = true;
            }

            if ( isAValidRecipe )
            {
                waitingRecipesList.RemoveAt(i);
                recipesAcumulated--;
                break;
            }
        }

        if (isAValidRecipe) {

            Debug.Log("Is a valid recipe!!!");

        }
        else {

            Debug.Log("Invalid Recipe");

        }
    }

    public static DeliveryManager GetInstance() {
        return instance;
    }
}
