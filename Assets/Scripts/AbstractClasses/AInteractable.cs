using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AInteractable: MonoBehaviour
{
    protected Transform pickPoint;
    protected KitchenObject kitchenObjectOnPickPoint;

    protected void SetPickPoint()
    {
        this.pickPoint = this.transform.Find("PickPoint");
    }

    public Transform GetPickPoint() { 
        return pickPoint;
    }

    public void SetKitchenObject( KitchenObject kitchenObject ) { 
        this.kitchenObjectOnPickPoint = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObjectOnPickPoint;
    }

    public void clearKitchenObject() {
        this.kitchenObjectOnPickPoint = null;
    }

    public bool hasKitchenObject() {
        return kitchenObjectOnPickPoint != null;
    }
}
