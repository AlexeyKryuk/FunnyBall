using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private int _coins = 0;

    private void OnEnable()
    {
        _player.CoinCollecting += OnCoinCollecting;
    }

    private void OnDisable()
    {
        _player.CoinCollecting -= OnCoinCollecting;
    }

    private void OnCoinCollecting(int value)
    {
        _coins += value;
        _text.text = _coins.ToString();
    }
}
