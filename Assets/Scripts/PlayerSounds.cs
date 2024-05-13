using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private Player player;
    private float timer = 0;
    private float timerMax = .1f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if ( player.IsWalking() ) {

            timer += Time.deltaTime;

            if (timer >= timerMax)
            {
                SoundManager.GetInstance().PlayPlayerFootSteps(player.transform.position);
                timer = 0;
            }
        }
    }
}
