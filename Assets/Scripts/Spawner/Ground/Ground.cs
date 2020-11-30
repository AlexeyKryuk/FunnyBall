using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ground : SpawnObject
{
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

    private bool _isUsed = false;

    public bool IsUsed => _isUsed;
    public Transform LeftBorder => _leftBorder;
    public Transform RightBorder => _rightBorder;

    public UnityEvent CollidedIntoPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player) && !_isUsed)
        {
            CollidedIntoPlayer?.Invoke();
            _isUsed = true;
        }
    }

    private void OnDisable()
    {
        _isUsed = false;
    }
}
