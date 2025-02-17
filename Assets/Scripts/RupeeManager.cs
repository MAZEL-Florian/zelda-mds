using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
public class RupeeManager : MonoBehaviour
{

    public Transform spawner;
    public Rupee prefab;
    public Transform container;
    public float spawnDelay = 1f;
    public List<RupeeData> rupeeDataList = new List<RupeeData>();
    private readonly List<Rupee> _rupees = new List<Rupee>();
    private Coroutine _spawnRoutine;

    public event Action<Rupee> OnCollected;

    public void StartGame()
    {
        StartSpawning();
    }

    public void StopGame()
    {
        StopSpawning();
        for (var i = _rupees.Count - 1; i >= 0; i--)
        {
            RemoveRupee(_rupees[i]);
        }
    }

    public void StartSpawning()
    {
        _spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    public void StopSpawning()
    {
        if (_spawnRoutine == null) return;
        StopCoroutine(_spawnRoutine);
        _spawnRoutine = null;

    }

    private void Spawn()
    {
        var data = rupeeDataList[UnityEngine.Random.Range(0, rupeeDataList.Count)];
        var rupee = Instantiate(prefab, spawner.position, Quaternion.identity);
        rupee.transform.parent = container;
        rupee.Data = data;
        AddRupee(rupee);
    }

    private IEnumerator SpawnRoutine()
    {
        Spawn();
        yield return new WaitForSeconds(spawnDelay);
        StartSpawning();
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
        Destroy(rupee.gameObject);
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        OnCollected?.Invoke(rupee);
        RemoveRupee(rupee);
    }
}
