using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : ABaseCounter
{
    private float timerMaxValue = 4;
    private float timer;
    private int spawnMaxCount = 4;
    private int spawnCount;

    public event EventHandler OnSpawnCountIncrease;
    public event EventHandler OnSpawnCountDecrease;

    private void Awake()
    {
        spawnCount = 0;
        timer = 0;
    }

    private void Update()
    {
        SpawnPlateByTime();
    }

    private void SpawnPlateByTime() {

        if (spawnCount < spawnMaxCount ) {

            timer += Time.deltaTime;

            if (timer >= timerMaxValue)
            {
                timer = 0;
                spawnCount++;
                OnSpawnCountIncrease?.Invoke(this, EventArgs.Empty);
            }
        }   
    }

    public override void Interact(ABaseCounter counterInteracted, Player player)
    {
        if ( counterInteracted == this ) {
            
            bool areDishesAvailable = spawnCount > 0;

            if (!player.hasKitchenObject() && areDishesAvailable)
            {
                KitchenObject.Create( kitchenObjectSO.prefab , player );
                spawnCount--;
                OnSpawnCountDecrease?.Invoke(this, EventArgs.Empty);
            }

        }
    }
}
