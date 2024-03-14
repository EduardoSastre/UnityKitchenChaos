using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AInteractObject: MonoBehaviour
{
    protected GameInput gameInput = GameInput.getInstance();


    protected bool isInteractionButtonPressed() {

        return gameInput.getInputAction().Player.Interact.triggered;

    }

    public abstract void Interact(bool canInteract);

    public GameObject GetVisualObject() { 
        return this.transform.GetChild(0).GetChild(0).gameObject;
    }
}
