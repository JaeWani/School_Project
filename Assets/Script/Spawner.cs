using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    public Transform[] SpawnPoint;
    private static float _SpawnDelay = 1;
    public float SpawnDelay
    {
        get
        {
            return _SpawnDelay;
        }
        set
        {
            _SpawnDelay = value;
            wait = new WaitForSeconds(_SpawnDelay);
        }
    }
    void Start()
    {
        SpawnPoint = GetComponentsInChildren<Transform>();
        SpawnLogic();
    }
    WaitForSeconds wait = new WaitForSeconds(_SpawnDelay);
   void SpawnLogic()
   {
        StartCoroutine(_Spawn());
        IEnumerator _Spawn()
        {
            yield return wait;
            GameObject enemy = ObjectPooler.SpawnFromPool("Ekans", SpawnPoint[Random.RandomRange(1,SpawnPoint.Length)].position);
            StartCoroutine(_Spawn());
        }
   }
}
