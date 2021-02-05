using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneJumpButton : MonoBehaviour
{
    [SerializeField] private string _nextSceneName;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(GoToScene);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(GoToScene);
    }

    public void GoToScene()
    {
        SceneManager.LoadScene(_nextSceneName);
        Time.timeScale = 1;
    }
}
