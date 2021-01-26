using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : ObjectPool<Coin>
{
    [SerializeField] private Coin[] _coinPrefab;
    [SerializeField] private float _distanceBetweenCoin;
    [SerializeField] private Transform _startPoint;

    private ObjectPool<Coin> _objectPool;

    private void Awake()
    {
        Initialize(_coinPrefab, Container, Quaternion.identity);
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
        Vector2 deltaPosition = _startPoint.position + Vector3.right;
        deltaPosition.y += Random.Range(0f, 1f);

        for (int i = 1; i < Pool.Count + 1; i++)
        {
            Coin coin = GetObject();

            coin.gameObject.SetActive(true);
            coin.transform.position = deltaPosition;
            deltaPosition.x += _distanceBetweenCoin;
        }
    }
}
