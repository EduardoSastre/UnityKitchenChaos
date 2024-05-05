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
        platesCounter.OnSpawnCountIncrease += PlatesCounter_OnSpawnCountIncrease;
        platesCounter.OnSpawnCountDecrease += PlatesCounter_OnSpawnCountDecrease;
        platesVisualList = new List<GameObject>();
    }

    private void PlatesCounter_OnSpawnCountIncrease(object sender, System.EventArgs e)
    {
        CreateVisualPlate();
    }

    private void CreateVisualPlate()
    {

        GameObject plateCreated = Instantiate(plateVisual, platesCounter.GetPickPoint(), false);
        platesVisualList.Add(plateCreated);
        plateCreated.transform.localPosition = new Vector3(0, plateVisualOffsetY * platesVisualList.Count, 0);
    }

    private void PlatesCounter_OnSpawnCountDecrease(object sender, System.EventArgs e)
    {
        DeleteVisualPlate();
    }

    private void DeleteVisualPlate()
    {
        GameObject topPlateInPile = platesVisualList[platesVisualList.Count - 1];
        platesVisualList.Remove(topPlateInPile);
        Destroy(topPlateInPile);
        
    }


}
