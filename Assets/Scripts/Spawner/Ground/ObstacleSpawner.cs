using Assets.Scripts.Spawner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ground))]
public class ObstacleSpawner : ObjectPool
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Obstacle[] _obstaclePrefabs;

    private Obstacle _currentObstacle;
    private Ground _ground;

    private void Awake()
    {
        _ground = GetComponent<Ground>();

        Initialize(_obstaclePrefabs, _container, Quaternion.identity);
    }

    private void OnEnable()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            _currentObstacle = (Obstacle)GetObject();

            if (_currentObstacle != null)
            {
                _currentObstacle.gameObject.SetActive(true);
                _currentObstacle.transform.position = spawnPoint.position - _currentObstacle.Anchor.localPosition;
                _currentObstacle.Spawned?.Invoke(_ground.LeftBorder, _ground.RightBorder);
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
