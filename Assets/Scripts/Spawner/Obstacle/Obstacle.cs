using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Obstacle : MonoBehaviour
{
    private Collider2D _collider;
    
    public Ground Ground { get; private set; }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.Kill();
        }
    }

    public void Init(Ground ground)
    {
        Ground = ground;
    }
}
