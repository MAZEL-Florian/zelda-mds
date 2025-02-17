using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; } = 0;

    public int BestScore { get; private set; } = 0;


    private GameManager _gm;

    private void Awake()
    {
        _gm = GameManager.Instance;
        _gm.RupeeManager.OnCollected += RupeeCollectedHandler;
    }
    private void Start()
    {
        BestScore = PlayerPrefs.GetInt("best-score", 0);
    }
    private void RupeeCollectedHandler(Rupee rupee)
    {
        Score += rupee.Data.score;

        if (Score >= BestScore)
        {
            BestScore = Score;
            PlayerPrefs.SetInt("best-score", BestScore);
        }
    }

    public void StartGame()
    {
        Score = 0;
    }
}
