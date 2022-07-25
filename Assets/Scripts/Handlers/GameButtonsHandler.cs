using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameButtonsHandler : MonoBehaviour
{
    [SerializeField] private Button _toMenu, _stay, _exit;
    [SerializeField] private GameObject _exitWindow;

    public Action Paused, Resumed;
    
    private void Awake()
    {
        AddListeners();
        AddListenersToExitWindow();
    }

    private void AddListeners()
    {
        _toMenu.onClick.AddListener((() =>
        {
            Paused?.Invoke();
            _toMenu.onClick.RemoveAllListeners();
            _exitWindow.SetActive(true);
        }));
    }

    private void AddListenersToExitWindow()
    {
        _stay.onClick.AddListener((() =>
        {
            Resumed?.Invoke();
            AddListeners();
            _exitWindow.SetActive(false);
        }));
        _exit.onClick.AddListener((() =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(2);
        }));
    }
}
