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
    public event Action<Rupee> OnRupeeCollected;
    public List<RupeeData> rupeeDataList = new List<RupeeData>();


    public void StartSpawning()
    {
        _spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    public void StopSpawning()
    {
        if (_spawnRoutine != null)
        {
            StopCoroutine(_spawnRoutine);
            _spawnRoutine = null;
        }
    }

    public void DestroyAllRupees()
    {
        for (var i = _rupees.Count - 1; i >= 0; i--)
        {
            RemoveRupee(_rupees[i]);
        }
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
        rupee.OnRupeeCollected += RupeeCollectionHandler;
        _rupees.Add(rupee);
    }

    private void RemoveRupee(Rupee rupee)
    {
        rupee.OnRupeeCollected -= RupeeCollectionHandler;
        _rupees.Remove(rupee);
        Destroy(rupee.gameObject);
    }

    private void RupeeCollectionHandler(Rupee rupee)
    {
        OnRupeeCollected?.Invoke(rupee);
        RemoveRupee(rupee);
    }
}
