using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ground))]
public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private Obstacle[] _templates;
    [SerializeField] private Transform _startPoint;

    private Ground _ground;
    private Obstacle[] _obstacles;

    private void Awake()
    {
        _ground = GetComponent<Ground>();
        Initialize();
    }

    private void Initialize()
    {
        _obstacles = new Obstacle[_amount];

        for (int i = 0; i < _amount; i++)
        {
            _obstacles[i] = Instantiate(_templates[Random.Range(0, _templates.Length)], transform);
            _obstacles[i].Init(_ground);
        }
    }

    private void OnEnable()
    {
        Generate();
    }

    private void OnDisable()
    {
        foreach (var obstacles in _obstacles)
        {
            obstacles.gameObject.SetActive(false);
        }
    }

    private void Generate()
    {
        float surfaceLenght = _ground.GetComponent<Collider2D>().bounds.size.x - 4f;
        float distanceBetweenObj = surfaceLenght / _amount;

        Vector3 deltaPosition = _startPoint.position;

        for (int i = 0; i < _amount; i++)
        {
            _obstacles[i].gameObject.SetActive(true);
            _obstacles[i].transform.position = deltaPosition;

            deltaPosition.x += distanceBetweenObj;
        }
    }
}
