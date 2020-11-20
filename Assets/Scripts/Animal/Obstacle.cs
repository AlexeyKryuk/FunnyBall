using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Obstacle : SpawnObject
{
    private Collider2D _collider;

    public event UnityAction<ObstacleSpawner> WasSpawned;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Physics2D.IgnoreCollision(collision.collider, _collider, true);
        }
        else if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.Kill();
        }
    }

    public void Init(ObstacleSpawner spawner)
    {
        WasSpawned?.Invoke(spawner);
    }
}
