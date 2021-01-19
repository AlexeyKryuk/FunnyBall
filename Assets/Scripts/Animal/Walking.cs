using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Waypoints _waypoints;

    private void Update()
    {
        Move(_waypoints.Target.position);

        if (_waypoints.IsForward)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;
    }

    private void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}
