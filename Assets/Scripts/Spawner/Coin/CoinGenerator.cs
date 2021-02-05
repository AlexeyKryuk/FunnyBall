using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private Coin _template;
    [SerializeField] private float _distanceBetweenCoin;
    [SerializeField] private Transform _startPoint;

    private Coin[] _coins;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _coins = new Coin[_amount];

        for (int i = 0; i < _amount; i++)
        {
            _coins[i] = Instantiate(_template, transform);
        }
    }

    private void OnEnable()
    {
        Generate();
    }

    private void OnDisable()
    {
        foreach (var coin in _coins)
        {
            coin.gameObject.SetActive(false);
        }
    }

    private void Generate()
    {
        Vector3 deltaPosition = _startPoint.position + Vector3.right;
        deltaPosition.y += Random.Range(0f, 1f);

        for (int i = 0; i < _amount; i++)
        {
            _coins[i].gameObject.SetActive(true);
            _coins[i].transform.position = deltaPosition;

            deltaPosition.x += _distanceBetweenCoin;
        }
    }
}
