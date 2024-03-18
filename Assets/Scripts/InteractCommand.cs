using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCommand : ICommand
{
    private AInteractObject interactObject;


    public InteractCommand( AInteractObject interactObject ) {
        this.interactObject = interactObject;
    }

    public void execute()
    {
        interactObject.Interact();
    }

}
