using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AboutButtonsHandler : MonoBehaviour
{
    [SerializeField] private Button _toMenu, _telegram, _github;

    private void Awake()
    {
        _toMenu.onClick.AddListener((() => SceneManager.LoadScene(2)));
        _telegram.onClick.AddListener((() => Application.OpenURL("t.me/lfybbk10")));
        _github.onClick.AddListener((() => Application.OpenURL("github.com/lfybbk10")));
    }
}
