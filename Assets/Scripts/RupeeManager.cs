using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
public class RupeeManager : MonoBehaviour
{

    public Transform spawner;
    public Rupee prefab;
    public Transform container;
    public float spawnDelay = 2f;
    private readonly List<Rupee> _rupees = new List<Rupee>();
    private Coroutine _spawnRoutine;

    public event Action<Rupee> OnCollected;

    void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        _spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    private void Spawn()
    {
        var rupee = Instantiate(prefab, spawner.position, Quaternion.identity);
        rupee.transform.parent = container;
        AddRupee(rupee);
    }

    private IEnumerator SpawnRoutine()
    {
        Spawn();
        yield return new WaitForSeconds(spawnDelay);
        StartSpawning();
    }

    void Update()
    {
        
    }

    private void AddRupee(Rupee rupee)
    {
        rupee.OnCollected += RupeeCollectedHandler;
        _rupees.Add(rupee);
    }

    private void RemoveRupee(Rupee rupee)
    {
        rupee.OnCollected -= RupeeCollectedHandler;
        _rupees.Remove(rupee);
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        OnCollected?.Invoke(rupee);
        RemoveRupee(rupee);
    }
}
