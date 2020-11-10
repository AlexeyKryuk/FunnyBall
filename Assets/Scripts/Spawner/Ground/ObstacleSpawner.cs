using Assets.Scripts.Spawner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : ObjectPool
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private SpawnObject[] _obstaclePrefabs;

    private SpawnObject _currentObstacle;

    private void Awake()
    {
        Initialize(_obstaclePrefabs, _container, Quaternion.identity);
    }

    private void OnEnable()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            _currentObstacle = GetObject();

            if (_currentObstacle != null)
            {
                SetObject(_currentObstacle, spawnPoint);
            }
        }
    }

    private void OnDisable()
    {
        foreach (var obj in Pool)
        {
            obj.gameObject.SetActive(false);
        }
    }

    private void SetObject(SpawnObject obstacle, Transform spawnPoint)
    {
        obstacle.gameObject.SetActive(true);
        obstacle.transform.position = spawnPoint.position - obstacle.Anchor.localPosition;
    }
}
