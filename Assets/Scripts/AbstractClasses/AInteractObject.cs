using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AInteractObject : MonoBehaviour
{
    private GameObject visualObject;

    private void Start()
    {
        visualObject = this.transform.GetChild(0).GetChild(0).gameObject;
    }

    public GameObject GetVisualObject() {
        return visualObject;
    }

    public abstract void Interact();

}
