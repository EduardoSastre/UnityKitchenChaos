using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownText;

    private void Start()
    {
        GameManager.GetInstance().OnStateChanged += GameManager_OnStateChanged;
        Hide();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.GetInstance().IsCountdownToStartActive())
        {
            Show();
        }
        else {
            Hide();
        }
    }

    private void Show() {
        
        countDownText.gameObject.SetActive(true);
    }

    private void Hide() {
        countDownText.gameObject.SetActive(false);
    }

    private void Update()
    {
        float timer = GameManager.GetInstance().GetCountdownToStartTimer();
        countDownText.text = Mathf.Ceil( timer ).ToString();
    }
}
