using Assets.Scripts.Spawner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : ObjectPool
{
    [SerializeField] private SpawnObject[] _coinPrefab;
    [SerializeField] private float _distanceBetweenCoin;
    [SerializeField] private Transform _startPoint;

    private void Awake()
    {
        Initialize(_coinPrefab, _container, Quaternion.identity);
    }

    private void OnEnable()
    {
        SpawnCoins();
    }

    private void OnDisable()
    {
        foreach (var obj in Pool)
        {
            obj.gameObject.SetActive(false);
        }
    }

    private void SpawnCoins()
    {
        Vector2 deltaPosition = _startPoint.position;
        for (int i = 1; i < Pool.Count + 1; i++)
        {
            var coin = GetObject();

            coin.gameObject.SetActive(true);
            coin.transform.position = deltaPosition;
            deltaPosition += new Vector2(_distanceBetweenCoin * i, 0);
        }
    }
}
