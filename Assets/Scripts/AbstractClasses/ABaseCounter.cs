using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABaseCounter : AInteractable
{

    [SerializeField] protected KitchenObjectSO kitchenObjectSO;
    [SerializeField] protected GameObject[] visualObjects;

    public void Start()
    {
        SetPickPoint();
        visualObjects = new GameObject[this.transform.Find("Selected").childCount];
    }

    public GameObject[] GetVisualObjects()
    {
        // Get the transform of the parent GameObject
        Transform parentTransform = this.transform.Find("Selected");

        // Iterate through all children and save them
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            // Get the child at index 'i'
            GameObject childTransform = parentTransform.GetChild(i).gameObject;
            
            visualObjects[i] = childTransform;

        }

        return visualObjects;

    }

}
