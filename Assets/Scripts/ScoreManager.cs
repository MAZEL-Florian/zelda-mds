using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; } = 0;
    private GameManager _gm;

    private void Awake()
    {
        _gm = GameManager.Instance;
        _gm.RupeeManager.OnCollected += RupeeCollectedHandler;
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        Score++;
        Debug.Log(Score);
    }
}
