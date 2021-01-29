using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class Waypoints : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Obstacle _obstacle;
    private int _currentIndex = 0;

    public Transform Target { get; private set; }
    public int Direction { get; private set; }

    private void Awake()
    {
        _obstacle = GetComponent<Obstacle>();
    }

    private void OnEnable()
    {
        if (_obstacle.Ground != null)
        {
            _points.Add(_obstacle.Ground.RightBorder);
            _points.Add(_obstacle.Ground.LeftBorder);
        }

        _currentIndex = 0;
        Target = _points[_currentIndex];

        Direction = 1;
        Render(Direction);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.position) <= 1f)
        {
            Target = Next();
            Render(Direction);
        }
    }

    public void Add(Transform point)
    {
        _points.Add(point);
    }

    private Transform Next()
    {
        _currentIndex += Direction;

        if (_currentIndex == _points.Count - 1)
        {
            Direction = -1;
        }
        else if (_currentIndex == 0)
        {
            Direction = 1;
        }

        return _points[_currentIndex];
    }

    private void Render(int direction)
    {
        if (direction == 1)
            _spriteRenderer.flipX = false;
        else if (direction == -1)
            _spriteRenderer.flipX = true;
    }
}