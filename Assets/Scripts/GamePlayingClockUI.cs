using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{
    [SerializeField] private Image image;

    private void Update()
    {
        image.fillAmount =  ( GameManager.GetInstance().GetGamePlayingTimerNormalized());
    }
}
