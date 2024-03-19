using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter :  AInteractable
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private KitchenObject kitchenObject;

    public void Start()
    {
        SetPickPoint();
    }

    public override void CancelInteract()
    {
        VisualBehaviour.CancelVisualInteraction(this);
    }

    public override void Interact(AInteractable interactObject) {

        if ( kitchenObject == null && !CheckObject.isNullOrEmpty(kitchenObjectSO.prefab) ) {

            kitchenObject = Instantiate(kitchenObjectSO.prefab, pickPoint).GetComponent<KitchenObject>();
            kitchenObject.transform.localPosition = Vector3.zero;
            
        }
        else if ( kitchenObject != null)
        {
            
            kitchenObject.transform.SetParent(interactObject.GetPickPoint(), false);
            kitchenObject.transform.localPosition = Vector3.zero;

        }


    }
}
