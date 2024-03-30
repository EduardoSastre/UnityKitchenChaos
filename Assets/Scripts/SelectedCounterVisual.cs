using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject[] visualObjects;

    private void Start()
    {
        addVisualObjects();
        Player.GetInstance().OnCounterInteraction += SelectedCounterVisual_OnCounterInteraction;
        GameInput.GetInstance().OnCancelAction += SelectedCounterVisual_OnCancelAction;
    }

    private void addVisualObjects()
    {
        int numVisualObjects = transform.childCount;
        visualObjects = new GameObject[numVisualObjects];

        for (int i = 0; i < numVisualObjects; i++)
        {
            visualObjects[i] = transform.GetChild(i).gameObject;
        }
    }

    private void SelectedCounterVisual_OnCounterInteraction(object sender, Player.OnCounterInteractionEventsArgs InteractedCounter)
    {
        ABaseCounter parentCounter = this.transform.parent.GetComponent<ABaseCounter>();

        if (InteractedCounter.counter == parentCounter)
        {
            PerformVisualInteraction();
        }
        else { 
            CancelVisualInteraction();
        }
    }

    private void SelectedCounterVisual_OnCancelAction(object sender, System.EventArgs e)
    {
        CancelVisualInteraction();
    }

    private void PerformVisualInteraction()
    {
        changeActiveForVisuals(true);
    }

    private void CancelVisualInteraction()
    {
        changeActiveForVisuals(false);
    }

    private void changeActiveForVisuals(bool value) {

        foreach (GameObject visualObject in visualObjects)
        {
            visualObject.SetActive(value);
        }
    }
}
