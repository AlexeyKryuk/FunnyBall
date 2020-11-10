using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Obstacle : MonoBehaviour
{
    private Collider2D _collider;

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
}
