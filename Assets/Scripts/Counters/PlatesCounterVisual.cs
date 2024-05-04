using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCounter platesCounter;
    private List<GameObject> platesVisualList;
    [SerializeField] private GameObject plateVisual;
    private float plateVisualOffsetY = 0.1f;

    private void Start()
    {
        platesCounter.OnSpawnCountChanged += PlatesCounter_OnSpawnCountChanged;
        platesVisualList = new List<GameObject>();
    }

    private void PlatesCounter_OnSpawnCountChanged(object sender, System.EventArgs e)
    {
        SpawnVisualPlate();
    }

    private void SpawnVisualPlate() {

        GameObject plateCreated = Instantiate(plateVisual, platesCounter.GetPickPoint(), false);
        platesVisualList.Add(plateCreated);
        plateCreated.transform.localPosition = new Vector3(0, plateVisualOffsetY * platesVisualList.Count  ,0);
    }
}
