using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Ground _ground;

    private Transform _leftPoint;
    private Transform _rightPoint;
    private Transform _targetPoint;

    private void Awake()
    {
        _ground = GetComponentInParent<Ground>();
    }

    private void OnEnable()
    {
        _leftPoint = _ground.LeftBorder;
        _rightPoint = _ground.RightBorder;
        _targetPoint = _leftPoint;
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

    private void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}
