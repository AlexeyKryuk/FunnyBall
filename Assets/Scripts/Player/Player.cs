using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int _countOfCoins;

    public UnityAction<int> CoinPickedUp;

    public int CountOfCoins => _countOfCoins;

    public void Kill()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PickUpCoin(int count)
    {
        if (count > 0)
            _countOfCoins += count;

        CoinPickedUp?.Invoke(count);
    }
}
