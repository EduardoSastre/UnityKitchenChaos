using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter :  AInteractObject
{

    public override void Interact(bool canInteract) {

        SelectedInteractableObject.PerformVisualInteraction(this, canInteract);

    }
}
