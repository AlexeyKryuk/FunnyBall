using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAnimation : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _duration;
    [SerializeField] private float _strength;
    [SerializeField] private int _vibration;
    [SerializeField] private float _randomness;
    [SerializeField] private bool _snapping;
    [SerializeField] private bool _fadeOut;

    private Sequence _sequence;

    private void OnEnable()
    {
        _sequence = null;
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
