using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAnimation : MonoBehaviour
{
    [SerializeField] private Ground _ground;
    [SerializeField] private float _delay;
    [SerializeField] private float _duration;

    private float _strength = 0.2f;
    private int _vibration = 5;
    private float _randomness = 100f;
    private bool _snapping = false;
    private bool _fadeOut = false;

    private Sequence _sequence;

    private void OnEnable()
    {
        _ground.CollidedIntoPlayer += Fall;
        _sequence = null;
    }

    private void OnDisable()
    {
        _ground.CollidedIntoPlayer -= Fall;
    }

    public void Fall()
    {
        if (_sequence == null)
        {
            _sequence = DOTween.Sequence();

            _sequence.Append(transform.DOShakePosition(_duration, Vector3.left * _strength,
                _vibration, _randomness, _snapping, _fadeOut).SetDelay(_delay));
            _sequence.Append(transform.DOMove(transform.position + Vector3.down * 15f, 1f));
            _sequence.AppendCallback(() => gameObject.SetActive(false));
        }
    }
}
