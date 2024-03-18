using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter :  AbstInteractObject
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private void Start()
    {
        counterTopPoint = this.transform.GetChild(2).transform;
    }

    public override void Interact(bool canInteract) {

        SelectedInteractableObject.PerformVisualInteraction(this, canInteract);

        if ( canInteract && !CheckObject.isNullOrEmpty(kitchenObjectSO.prefab) ) {

            GameObject kitchenObject = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObject.transform.localPosition = Vector3.zero;
            kitchenObject.GetComponent<KitchenObject>().setClearCounter(this);

        }

    }
}
