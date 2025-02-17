using UnityEngine;
using System;

public class UiManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI bestscore;

    public TMPro.TextMeshProUGUI time;

    public GameObject startButton;

    private GameManager _gm;

    private void Awake()
    {
        _gm = GameManager.Instance;

    }

    private void Update()
    {
        score.text = $"Score: {_gm.ScoreManager.Score}";
        bestscore.text = $"Best Score: {_gm.ScoreManager.BestScore}";
        time.text = $"{TimeSpan.FromSeconds(_gm.TimeManager.Remaining):mm\\:ss}";
    }

    public void StartGame()
    {
        startButton.SetActive(false);
    }

    public void StopGame()
    {
        startButton.SetActive(true);
    }
}
