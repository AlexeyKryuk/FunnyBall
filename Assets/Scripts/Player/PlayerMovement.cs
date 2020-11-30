using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PhysicsMovement
{
    [SerializeField] private Animator _animator;

    private Vector2 _targetVelocity;

    private void Update()
    {
        _targetVelocity.x = Input.GetAxis("Horizontal");
        _animator.SetFloat("Speed", _targetVelocity.x);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (TryToJump())
            {
                _animator.SetTrigger("Jump");
            }
        }
    }

    private void FixedUpdate()
    {
        Move(_targetVelocity);
    }
}
