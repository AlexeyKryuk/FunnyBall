using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints;

    private int _currentPointIndex = 0;
    private bool _isForward = true;

    public int CurrentPointIndex 
    {
        get => _isForward ? _currentPointIndex++ : _currentPointIndex--;
    }

    public void Add(Transform point)
    {
        _wayPoints.Add(point);
    }

    public Transform Next()
    {
        if (_currentPointIndex == _wayPoints.Count - 1)
        {
            _isForward = false;
        }
        else if (_currentPointIndex == 0)
        {
            _isForward = true;
        }

        return _wayPoints[CurrentPointIndex];
    }
}