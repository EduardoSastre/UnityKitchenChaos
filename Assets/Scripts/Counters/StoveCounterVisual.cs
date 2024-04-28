using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject[] visualObjects;

    [SerializeField] private StoveCounter stoveCounter;


    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs state)
    {
        if (state.currentState == StoveCounter.State.Frying || state.currentState == StoveCounter.State.Fried) {

            foreach (GameObject visualObject in visualObjects)
            {
                visualObject.SetActive(true);
            }

        } else {

            foreach (GameObject visualObject in visualObjects)
            {
                visualObject.SetActive(false);
            }

        }

    }
}
