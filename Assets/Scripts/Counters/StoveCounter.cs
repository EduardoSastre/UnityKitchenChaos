using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CuttingCounter;

public class StoveCounter : ABaseCounter
{
    /// <summary>
    /// ////////////////// MIN 5:35:39
    /// </summary>
    [SerializeField] FryingRecipeSO[] fryingRecipeSOArray;
    private float timer = 0;
    private State currentState;
    private FryingRecipeSO currentFryingRecipeSO;
    private bool shouldFry = false;

    private enum State { 
        Idle,
        Frying,
        Fried,
        Burned
    }

    private void OnEnable()
    {
        ChangeToState(State.Idle);
    }

    private void Update()
    {
        if (shouldFry) {
            StartProcess();
        }
        Debug.Log(shouldFry);
        Debug.Log(currentState);
        Debug.Log("");
    }

    public override void Interact(ABaseCounter counterInteracted, Player player)
    {
        if (counterInteracted == this)
        {

            if (CheckObject.isNullOrEmpty(kitchenObject) && player.hasKitchenObject() && hasKitchenObjectRecipeOutput( player.GetKitchenObject() ))
            {
                KitchenObject.ChangeParent(player, this);
            }
            else if (!CheckObject.isNullOrEmpty(kitchenObject) && !player.hasKitchenObject())
            {
                KitchenObject.ChangeParent(this, player);
            }
        }
    }

    private Boolean hasKitchenObjectRecipeOutput( KitchenObject kitchenObject ) {

        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray) {

            Debug.Log(kitchenObject.GetKitchenObjectSO().name);
                Debug.Log(fryingRecipeSO.inputObjectSO.name);
            Debug.Log("");

            if (kitchenObject.GetKitchenObjectSO() == fryingRecipeSO.inputObjectSO) {
                currentFryingRecipeSO = fryingRecipeSO;
                return true;
            }

        }

        return false;
    }

    public override void InteractAlternate()
    {
        if (!CheckObject.isNullOrEmpty(kitchenObject))
        {
            shouldFry = shouldFry == true ? false : true;
        }
    }

    private void ChangeToState( State state ) {
        currentState = state;
    }

    private void ClearTimer() {
        timer = 0;
    }

    private void StartProcess() {
        timer += Time.deltaTime;

        if (timer >= currentFryingRecipeSO.fryingTimerMax ) {

            UpdateState();
            ClearTimer();
        }
    }

    private void UpdateState() {
        switch (currentState)
        {
            case State.Idle:
                if (hasKitchenObjectRecipeOutput(kitchenObject))
                {
                    ChangeToState(State.Frying);
                }               
                break;
            case State.Frying:
                if (hasKitchenObjectRecipeOutput(kitchenObject)) {
                    ChangeInputForOutput(currentFryingRecipeSO);
                    ChangeToState(State.Fried);
                }                
                break;
            case State.Fried:
                if (hasKitchenObjectRecipeOutput(kitchenObject))
                {
                    ChangeInputForOutput(currentFryingRecipeSO);
                    ChangeToState(State.Burned);
                }             
                break;
            case State.Burned:
                break;
        }
    }

    /*  Coroutine example
     * 
     * private IEnumerator HandleFryTimer() { 
        yield return new WaitForSeconds(1f);
    }

    public void Start()
    {
        StartCoroutine(HandleFryTimer());
    }*/

    private void ChangeInputForOutput(FryingRecipeSO fryingRecipeSO)
    {

        if (!CheckObject.isNullOrEmpty(kitchenObject))
        {
            KitchenObject.Destroy(kitchenObject.gameObject, this);
            KitchenObject.Create(fryingRecipeSO.outputObjectSO.prefab, this);
        }

    }
}
