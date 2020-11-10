using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Transform _LeftPoint;
    private Transform _RightPoint;
    private Transform _targetPoint;

    private void OnEnable()
    {
        _LeftPoint = GetComponentInParent<GroundSpawnObject>().LeftBorder;
        _RightPoint = GetComponentInParent<GroundSpawnObject>().RightBorder;

        _targetPoint = _LeftPoint;
        _spriteRenderer.flipX = true;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.localPosition, _targetPoint.localPosition) <= 1.2f)
        {
            if (_targetPoint == _LeftPoint)
            {
                _targetPoint = _RightPoint;
                _spriteRenderer.flipX = false;
            }
            else
            {
                _targetPoint = _LeftPoint;
                _spriteRenderer.flipX = true;
            }
        }

        Move(_targetPoint.position);
    }

    private void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}
