using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter :  AInteractable
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private GameObject kitchenObject;

    public override void Interact(bool canInteract, AInteractable interactObject) {

        SelectedInteractableObject.PerformVisualInteraction(this, canInteract);

        Debug.Log(interactObject.name);

        if ( canInteract && kitchenObject == null && !CheckObject.isNullOrEmpty(kitchenObjectSO.prefab) ) {

            kitchenObject = Instantiate(kitchenObjectSO.prefab, pickPoint);
            kitchenObject.transform.localPosition = Vector3.zero;
            kitchenObject.GetComponent<KitchenObject>().setParent(this);

        }

        if (canInteract && kitchenObject != null)
        {
            kitchenObject.GetComponent<KitchenObject>().setParent(interactObject);
        }


    }
}
