using Assets.Scripts.Spawner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleSpawner : ObjectPool<Obstacle>
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Obstacle[] _obstaclePrefabs;

    private Obstacle _currentObstacle;

    private void Awake()
    {
        Initialize(_obstaclePrefabs, Container, Quaternion.identity);
    }

    private void OnEnable()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            _currentObstacle = GetObject();

            if (_currentObstacle != null)
            {
                _currentObstacle.gameObject.SetActive(true);
                _currentObstacle.transform.position = spawnPoint.position - _currentObstacle.Anchor.localPosition;
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
}
