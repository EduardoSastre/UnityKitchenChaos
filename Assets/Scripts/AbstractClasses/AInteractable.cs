using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AInteractable: MonoBehaviour
{
    protected Transform pickPoint;
    protected KitchenObject kitchenObject;

    protected void SetPickPoint()
    {
        this.pickPoint = this.transform.Find("PickPoint");
    }

    public Transform GetPickPoint() { 
        return pickPoint;
    }

    public void SetKitchenObject( KitchenObject kitchenObject ) { 
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void clearKitchenObject() {
        this.kitchenObject = null;
    }

    public bool hasKitchenObject() {
        return kitchenObject != null;
    }
}
