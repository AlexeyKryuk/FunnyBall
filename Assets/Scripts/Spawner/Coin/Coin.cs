using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : SpawnObject
{
    [SerializeField] private int _value = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            player.PickUpCoin(_value);
            gameObject.SetActive(false);
        }
    }
}
