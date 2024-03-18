using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualObjectBehaviour {

    private static AInteractObject currentInteractObject;

    public static void PerformVisualInteraction( AInteractObject interactObject ) {

        if (interactObject != currentInteractObject)
        {
            Hide();
            currentInteractObject = interactObject;
        }

        if (interactObject != null) {
            Show();
        }
        else {
            Hide();
        }
    
    }

    private static void Show() {
        currentInteractObject.GetVisualObject().SetActive(true);
    }
    private static void Hide() {
        currentInteractObject.GetVisualObject().SetActive(false);
    }
}
