using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public UnityAction<int> CoinPickedUp;

    public int Coins { get; private set; }

    public void Kill()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PickUpCoin(int count)
    {
        if (count > 0)
            Coins += count;

        CoinPickedUp?.Invoke(count);
    }
}
