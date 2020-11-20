using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private GameObject _menuWindow;

    private bool _isMenuActive = false;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(SetActiveMenu);
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(SetActiveMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetActiveMenu();
        }
    }

    private void SetActiveMenu()
    {
        _isMenuActive = !_isMenuActive;

        for (int i = 0; i < transform.childCount; i++)
        {
            _menuWindow.SetActive(_isMenuActive);
        }

        Time.timeScale = Convert.ToInt32(!_isMenuActive);
    }
}
