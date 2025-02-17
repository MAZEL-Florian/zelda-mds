using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public RupeeManager RupeeManager { get; private set; }

    public ScoreManager ScoreManager { get; private set; }

    public UiManager UiManager { get; private set; }

    public TimeManager TimeManager { get; private set; }

    public AudioManager AudioManager { get; private set; }


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        RupeeManager = GetComponent<RupeeManager>();
        ScoreManager = GetComponent<ScoreManager>();
        TimeManager = GetComponent<TimeManager>();
        AudioManager = GetComponent<AudioManager>();
        UiManager = GetComponent<UiManager>();
    }
    //private void Start()
    //{
    //    TimeManager.Reset();
    //    TimeManager.StartTimer();
    //}

    public void StartGame()
    {
        TimeManager.OnTimeUp += TimeUpHandler;
        TimeManager.Reset();
        UiManager.StartGame();
        ScoreManager.StartGame();
        RupeeManager.StartGame();
        AudioManager.StartGame();
        TimeManager.StartTimer();
    }

    public void StopGame()
    {
        TimeManager.OnTimeUp -= TimeUpHandler;
        UiManager.StopGame();
        AudioManager.StopGame();
        RupeeManager.StopGame();
    }

    private void Start()
    {
        TimeManager.OnTimeUp += TimeUpHandler;
    }

    private void TimeUpHandler()
    {
        StopGame();
    }
}
