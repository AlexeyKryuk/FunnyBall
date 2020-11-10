using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private int _countOfCoins = 0;

    private void OnEnable()
    {
        _player.CoinPickedUp += OnCoinPickedUp;
    }

    private void OnDisable()
    {
        _player.CoinPickedUp -= OnCoinPickedUp;
    }

    private void OnCoinPickedUp(int value)
    {
        _countOfCoins += value;
        _text.text = _countOfCoins.ToString();
    }
}
