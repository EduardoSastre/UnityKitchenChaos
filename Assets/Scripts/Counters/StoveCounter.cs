using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CuttingCounter;

public class StoveCounter : ABaseCounter
{
    /// <summary>
    /// ////////////////// MIN 5:47:00
    /// </summary>
    /// 

    //TODO: Implement visual behavour in stove counter visual
    [SerializeField] FryingRecipeSO[] fryingRecipeSOArray;
    private float timer = 0;
    private State currentState;
    private FryingRecipeSO currentFryingRecipeSO;
    private bool shouldFry = false;

    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs
    {
        public State currentState;
    }

    public enum State { 
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

    public bool IsFrying() {
        return shouldFry;
    }

    public override void Interact(ABaseCounter counterInteracted, Player player)
    {
        if (counterInteracted == this)
        {

            if (CheckObject.isNullOrEmpty(kitchenObjectOnPickPoint) && player.hasKitchenObject() && hasKitchenObjectRecipeOutput( player.GetKitchenObject() ))
            {
                KitchenObject.ChangeParent(player, this);
                ResetStove();
            }
            else if (!CheckObject.isNullOrEmpty(kitchenObjectOnPickPoint) && !player.hasKitchenObject())
            {
                KitchenObject.ChangeParent(this, player);
            }
        }
    }

    private Boolean hasKitchenObjectRecipeOutput( KitchenObject kitchenObject ) {

        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray) {

            if (kitchenObject.GetKitchenObjectSO() == fryingRecipeSO.inputObjectSO) {
                currentFryingRecipeSO = fryingRecipeSO;
                return true;
            }

        }

        return false;
    }

    public override void InteractAlternate()
    {
        if (!CheckObject.isNullOrEmpty(kitchenObjectOnPickPoint))
        {
            shouldFry = shouldFry == true ? false : true;
            currentState = currentState == State.Idle ? State.Frying : State.Idle; 
        }
    }

    private void ResetStove() { 
        ClearTimer();
        shouldFry = false;
        ChangeToState(State.Idle);
    }

    private void ClearTimer() {
        timer = 0;
    }

    private void ChangeToState(State state)
    {
        currentState = state;

        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
        {
            currentState = this.currentState
        });
    }

    private void StartProcess() {

        if ( CheckObject.isNullOrEmpty(kitchenObjectOnPickPoint) || !hasKitchenObjectRecipeOutput(kitchenObjectOnPickPoint)) {
            return;
        }

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
                break;
            case State.Frying:
                ChangeToState(State.Fried);
                break;
            case State.Fried:
                if (hasKitchenObjectRecipeOutput(kitchenObjectOnPickPoint))
                {
                    ChangeInputForOutput(currentFryingRecipeSO);                   
                }
                ChangeToState(State.Burned);
                break;
            case State.Burned:
                if (hasKitchenObjectRecipeOutput(kitchenObjectOnPickPoint))
                {
                    ChangeInputForOutput(currentFryingRecipeSO);
                }
                ResetStove();
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

        if (!CheckObject.isNullOrEmpty(kitchenObjectOnPickPoint))
        {
            KitchenObject.Destroy(kitchenObjectOnPickPoint.gameObject, this);
            KitchenObject.Create(fryingRecipeSO.outputObjectSO.prefab, this);
        }

    }
}
