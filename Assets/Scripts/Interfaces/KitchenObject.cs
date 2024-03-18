using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KitchenObject : MonoBehaviour 
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;


    public KitchenObjectSO GetKitchenObjectSO() { return kitchenObjectSO; }

    public  ClearCounter getClearCounter() { 
        return clearCounter;
    }

    public void setClearCounter( ClearCounter clearCounter ) {
        this.clearCounter = clearCounter;
    }

}
