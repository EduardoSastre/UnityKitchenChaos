using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDelivered;

    private void Start()
    {
        GameManager.GetInstance().OnStateChanged += GameManager_OnStateChanged;
        Hide();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.GetInstance().IsGameOver())
        {
            recipesDelivered.text = DeliveryManager.GetInstance().GetRecipesDelivered().ToString();
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {

        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }


}
