using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public const float MinMoveDistance = 0.0001f;
    public const float ShellRadius = 0.01f;
    public const int ExtraJumps = 2;

    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _jumpForce = 2f;
    [SerializeField] private float _minGroundNormalY = .65f;
    [SerializeField] private float _gravityModifier = 1f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rb;
    private Vector2 _velocity;
    private int _extraJumpsValue;
    private Vector2 _targetVelocity;
    private Vector2 _groundNormal;
    private ContactFilter2D _contactFilter;
    private RaycastHit2D[] _hitBuffer = new RaycastHit2D[16];
    private List<RaycastHit2D> _hitBufferList = new List<RaycastHit2D>(16);

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _extraJumpsValue = ExtraJumps;
        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask(_layerMask);
        _contactFilter.useLayerMask = true;
    }

    private void Update()
    {
        _targetVelocity = new Vector2(Input.GetAxis("Horizontal"), 0);
        _animator.SetFloat("Speed", _targetVelocity.x);

        if (Input.GetKeyDown(KeyCode.Space) && _extraJumpsValue > 0)
        {
            _extraJumpsValue--;
            _velocity.y = _jumpForce;

            _animator.Play("Jump");
        }
    }

    private void FixedUpdate()
    {
        _velocity += _gravityModifier * Physics2D.gravity * Time.fixedDeltaTime;
        _velocity.x = _targetVelocity.x;

        Vector2 deltaPosition = _velocity * Time.fixedDeltaTime;
        Vector2 moveAlongGround = new Vector2(_groundNormal.y, -_groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x * _moveSpeed;

        Move(move, false);

        move = Vector2.up * deltaPosition.y;

        Move(move, true);
    }

    private void Move(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > MinMoveDistance)
        {
            int count = _rb.Cast(move, _contactFilter, _hitBuffer, distance + ShellRadius);

            _hitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                _hitBufferList.Add(_hitBuffer[i]);
            }

            for (int i = 0; i < _hitBufferList.Count; i++)
            {
                Vector2 currentNormal = _hitBufferList[i].normal;
                if (currentNormal.y > _minGroundNormalY)
                {
                    _extraJumpsValue = ExtraJumps;
                    if (yMovement)
                    {
                        _groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(_velocity, currentNormal);
                if (projection < 0)
                {
                    _velocity = _velocity - projection * currentNormal;
                }

                float modifiedDistance = _hitBufferList[i].distance - ShellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        _rb.position = _rb.position + move.normalized * distance;
    }
}
