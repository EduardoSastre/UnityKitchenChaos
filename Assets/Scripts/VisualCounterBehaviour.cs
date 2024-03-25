using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCounterBehaviour : MonoBehaviour
{
    public static void PerformVisualInteraction( ABaseCounter interactObject ) {

        //Get the gameobject that groups all visual objects
        GameObject[] group = interactObject.GetVisualObjects();

        interactObject.gameObject.SetActive( true );

        foreach (GameObject child in group)
        {
            child.SetActive( true );
        }

    }

    public static void CancelVisualInteraction(ABaseCounter interactObject)
    {

        GameObject[] group = interactObject.GetVisualObjects();

        //interactObject.gameObject.SetActive(false);

        bool shouldSetActive = interactObject.isActiveAndEnabled;

        if (shouldSetActive)
        {
            foreach (GameObject child in group)
            {
                child.SetActive(false);
            }
        }
    }
}
