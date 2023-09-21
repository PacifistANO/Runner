using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Pool
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Healer _healerPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _timeBeforeSpawn;
    [SerializeField] private float _timeBeforeHealer;

    private float _pastTime;
    private float _pastTimeHealer;
    private int _numberOfSpawn;

    private void Start()
    {
        Initialize(_enemyPrefab.gameObject, _healerPrefab.gameObject);
    }

    private void Update()
    {
        _pastTime += Time.deltaTime;
        _pastTimeHealer += Time.deltaTime;

        if(_pastTime >= _timeBeforeSpawn)
        {
            if (_pastTimeHealer >= _timeBeforeHealer)
            {
                if (TryGetHealer(out GameObject healer))
                {
                    _pastTime = 0;
                    _pastTimeHealer = 0;
                    SetObject(healer);
                }
            }

            else if (TryGetEnemy(out GameObject enemy))
            {
                _pastTime = 0;
                SetObject(enemy);
            }
        }
    }

    private void SetObject(GameObject prefab)
    {
        prefab.SetActive(true);
        _numberOfSpawn = Random.Range(0, _spawnPoints.Length);
        prefab.transform.position = _spawnPoints[_numberOfSpawn].position;
    }
}
