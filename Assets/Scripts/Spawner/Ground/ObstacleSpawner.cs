using Assets.Scripts.Spawner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : ObjectPool
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Obstacle[] _obstaclePrefabs;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

    private Obstacle _currentObstacle;

    public Transform LeftBorder => _leftBorder;
    public Transform RightBorder => _rightBorder;

    private void Awake()
    {
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
                _currentObstacle.Init(this);
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
