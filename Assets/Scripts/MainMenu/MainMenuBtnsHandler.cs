using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuBtnsHandler : MonoBehaviour
{
    [SerializeField] private Button _newGame, _scoreRecords, _about, _exit;
    [SerializeField] private Button _stay, _finalExit;

    [SerializeField] private GameObject exitWindow;

    private void Awake()
    {
        AddListenersToMainBtns();
        AddListenersToExitWindow();
    }

    private void AddListenersToMainBtns()
    {
        _newGame.onClick.AddListener((() => SceneManager.LoadScene(0)));
        _scoreRecords.onClick.AddListener((() => SceneManager.LoadScene(1)));
        _about.onClick.AddListener((() => SceneManager.LoadScene(3)));
        _exit.onClick.AddListener((() =>
        {
            RemoveListenersFromMainBtns();
            exitWindow.SetActive(true);
        }));
    }

    private void RemoveListenersFromMainBtns()
    {
        _newGame.onClick.RemoveAllListeners();
        _scoreRecords.onClick.RemoveAllListeners();
        _about.onClick.RemoveAllListeners();
        _exit.onClick.RemoveAllListeners();
    }

    private void AddListenersToExitWindow()
    {
        _stay.onClick.AddListener((() =>
        {
            AddListenersToMainBtns();
            exitWindow.SetActive(false);
        }));
        _exit.onClick.AddListener((() => Application.Quit()));
    }
}
