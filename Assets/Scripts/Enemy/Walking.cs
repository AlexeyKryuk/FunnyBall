using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Directions
{
    Left,
    Right
}

public class Walking : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Waypoints _waypoints;

    private Transform _target;

    public Directions Direction { get; private set; }

    private void OnEnable()
    {
        _target = _waypoints.GetNext();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _target.position) < 1f)
        {
            _target = _waypoints.GetNext();
        }

        Move(_target.position);
        CalculateDirection();
    }

    private void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    private void CalculateDirection()
    {
        var heading = _target.position - transform.position;
        var direction = heading / heading.magnitude;

        if (direction.x > 0)
            Direction = Directions.Right;
        else
            Direction = Directions.Left;
    }
}
