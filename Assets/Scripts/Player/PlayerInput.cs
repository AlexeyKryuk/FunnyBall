using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    
    [SerializeField] private Animator _animator;
    [SerializeField] private PhysicsMovement _movement;

    private Vector2 _targetVelocity;

    private void Update()
    {
        _targetVelocity.x = Input.GetAxis(HorizontalAxis);
        _animator.SetFloat(AnimatorPlayerController.Params.Speed, _targetVelocity.x);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_movement.TryToJump())
            {
                _animator.SetTrigger(AnimatorPlayerController.Params.Jump);
            }
        }
    }

    private void FixedUpdate()
    {
        _movement.Move(_targetVelocity);
    }
}
