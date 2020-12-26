using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Ground _ground;
    private Queue<Transform> _wayPoints = new Queue<Transform>();


    private void Awake()
    {
        _ground = GetComponentInParent<Ground>();
    }

    private void OnEnable()
    {
        _wayPoints.Enqueue(_ground.RightBorder);
        _wayPoints.Enqueue(_ground.LeftBorder);
        _spriteRenderer.flipX = false;
    }

    private void Update()
    {
        Move(_wayPoints.Peek().position);

        if (Vector2.Distance(transform.position, _wayPoints.Peek().position) <= 1f)
        {
            _wayPoints.Enqueue(_wayPoints.Dequeue());
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
    }

    private void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}
