using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public RupeeManager RupeeManager { get; private set; }

    public ScoreManager ScoreManager { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        RupeeManager = GetComponent<RupeeManager>();
        ScoreManager = GetComponent<ScoreManager>();
    }

}
