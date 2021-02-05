using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class CreatorLabelAnimation : MonoBehaviour
{
    [SerializeField] private Button _creatorButton;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _creatorButton.onClick.AddListener(OnCreatorButtonClick);
    }

    private void OnDisable()
    {
        _creatorButton.onClick.RemoveListener(OnCreatorButtonClick);
    }

    private void OnCreatorButtonClick()
    {
        _animator.SetTrigger("ClickButton");
    }
}
