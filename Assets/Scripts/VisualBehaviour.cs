using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBehaviour : MonoBehaviour
{
    public static void PerformVisualInteraction( AInteractable interactObject ) {

        interactObject.GetVisualObject().SetActive(true);

    }

    public static void CancelVisualInteraction(AInteractable interactObject)
    {

        interactObject.GetVisualObject().SetActive(false);

    }
}
