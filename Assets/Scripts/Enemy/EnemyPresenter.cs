using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPresenter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Walking _walking;

    private void Update()
    {
        if (_walking.Direction == Directions.Left)
            _sprite.flipX = true;
        else
            _sprite.flipX = false;
    }
}
