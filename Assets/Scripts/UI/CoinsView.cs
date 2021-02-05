using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class CoinsView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _player.CoinCollected += OnCoinCollected;
    }

    private void OnDisable()
    {
        _player.CoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected(int count)
    {
        _text.text = count.ToString();
    }
}
