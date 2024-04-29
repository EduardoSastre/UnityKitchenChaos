using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressBar;
    [SerializeField] private Image barImage;

    private IHasProgress hasProgress;

    private void Start()
    {
        hasProgress = hasProgressBar.GetComponent<IHasProgress>();
        hasProgress.OnProgressChanged += HasProggres_OnProgressChanged;
        barImage.fillAmount = 0;
        Hide();
    }

    private void HasProggres_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;

        if (barImage.fillAmount == 0 || barImage.fillAmount == 1)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Show() { 
        this.gameObject.SetActive( true );
    }

    private void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
