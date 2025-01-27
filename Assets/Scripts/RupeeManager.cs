using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class RupeeManager : MonoBehaviour
{

    public Transform spawner;
    public Rupee prefab;
    public Transform container;
    public float spawnDelay = 2f;
    private readonly List<Rupee> _rupees = new List<Rupee>();
    private Coroutine _spawnRoutine;
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
}
