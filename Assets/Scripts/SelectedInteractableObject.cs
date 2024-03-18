using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedInteractableObject : MonoBehaviour
{
    public static void PerformVisualInteraction( AInteractable interactObject, bool isActive ) { 
    
        interactObject.GetVisualObject().SetActive(isActive);
    
    }
}
