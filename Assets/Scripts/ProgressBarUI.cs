using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter;
    [SerializeField] private Image barImage;

    private void Start()
    {
        cuttingCounter.OnProgressChanged += CuttingCounter_OnProgressChanged;
        barImage.fillAmount = 0;

        Hide();
    }

    private void CuttingCounter_OnProgressChanged(object sender, CuttingCounter.OnProgressChangedEventArgs progress )
    {
        barImage.fillAmount = progress.progressNormalized;

        if (barImage.fillAmount == 0 || barImage.fillAmount == 1)
        {
            Hide();
        }
        else { 
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
