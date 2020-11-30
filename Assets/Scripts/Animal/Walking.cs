using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class Walking : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Obstacle _obstacle;

    private Transform _leftPoint;
    private Transform _rightPoint;
    private Transform _targetPoint;

    private void Awake()
    {
        _obstacle = GetComponent<Obstacle>();
    }

    private void OnEnable()
    {
        _obstacle.Spawned.AddListener(SetBorders);
    }

    private void OnDisable()
    {
        _obstacle.Spawned.RemoveListener(SetBorders);
    }

    private void Update()
    {
        if (_targetPoint != null)
        {
            if (Vector2.Distance(transform.localPosition, _targetPoint.localPosition) <= 1.2f)
            {
                if (_targetPoint == _leftPoint)
                {
                    _targetPoint = _rightPoint;
                    _spriteRenderer.flipX = false;
                }
                else
                {
                    _targetPoint = _leftPoint;
                    _spriteRenderer.flipX = true;
                }
            }

            Move(_targetPoint.position);
        }
    }

    private void SetBorders(Transform leftBorder, Transform rightBorder)
    {
        _leftPoint = leftBorder;
        _rightPoint = rightBorder;
        _targetPoint = _leftPoint;
    }

    private void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}
