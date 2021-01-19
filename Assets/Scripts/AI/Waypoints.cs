using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    private int _currentIndex = 0;

    public Transform Target { get; private set; }
    public bool IsForward { get; private set; }

    private void OnEnable()
    {
        _currentIndex = 0;
        Target = _points[_currentIndex];
        IsForward = true;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.position) <= 1f)
        {
            Target = Next();
        }
    }

    public void Add(Transform point)
    {
        _points.Add(point);
    }

    private Transform Next()
    {
        if (IsForward)
            ++_currentIndex;
        else
            --_currentIndex;


        if (_currentIndex == _points.Count - 1)
        {
            IsForward = false;
        }
        else if (_currentIndex == 0)
        {
            IsForward = true;
        }

        return _points[_currentIndex];
    }
}