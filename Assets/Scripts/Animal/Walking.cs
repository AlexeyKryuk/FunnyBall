using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Waypoints _waypoints;

    private Ground _ground;
    private Transform _targetPoint;

    private void Awake()
    {
        _ground = GetComponentInParent<Ground>();
    }

    private void OnEnable()
    {
        _waypoints.Add(_ground.LeftBorder);
        _waypoints.Add(_ground.RightBorder);
        _targetPoint = _waypoints.Next();

        _spriteRenderer.flipX = true;
    }

    private void Update()
    {
        Move(_targetPoint.position);

        if (Vector2.Distance(transform.position, _targetPoint.position) <= 1f)
        {
            _targetPoint = _waypoints.Next();
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
    }

    private void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}
