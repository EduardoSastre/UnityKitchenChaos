using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KitchenObject : MonoBehaviour 
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;

    private AInteractable interactableObject;


    public KitchenObjectSO GetKitchenObjectSO() { return kitchenObjectSO; }

    public  AInteractable getClearCounter() { 
        return interactableObject;
    }

    public void setParent( AInteractable interactableObject ) {
        this.interactableObject = interactableObject;
        this.transform.parent = interactableObject.GetPickPoint();
    }

}
