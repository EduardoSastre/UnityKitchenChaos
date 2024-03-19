using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour 
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;

    private AInteractable parentObject;

    public KitchenObjectSO GetKitchenObjectSO() { return kitchenObjectSO; }

    public  AInteractable getParentObject() { 
        return parentObject;
    }

    /*public void setParent( AInteractable interactableObject ) {
        this.parentObject = interactableObject;

        Debug.Log(interactableObject.name);
        this.transform.parent = interactableObject.GetPickPoint();
    }*/

}
