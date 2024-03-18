using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AInteractable: MonoBehaviour
{
    protected Transform pickPoint;

    private void Start()
    {
        this.pickPoint = this.transform.GetChild(2);
    }

    public abstract void Interact(bool canInteract, AInteractable interactableObject);

    public GameObject GetVisualObject() { 
        return this.transform.GetChild(0).GetChild(0).gameObject;
    }

    public Transform GetPickPoint() { 
        return pickPoint;
    }
}
