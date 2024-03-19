using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AInteractable: MonoBehaviour
{
    protected Transform pickPoint;

    protected void SetPickPoint()
    {
        this.pickPoint = this.transform.Find("PickPoint");
    }

    public abstract void Interact(AInteractable interactableObject);

    public abstract void CancelInteract();

    public GameObject GetVisualObject() { 
        return this.transform.GetChild(0).GetChild(0).gameObject;
    }

    public Transform GetPickPoint() { 
        return pickPoint;
    }
}
