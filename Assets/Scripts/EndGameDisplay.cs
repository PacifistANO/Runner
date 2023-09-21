using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class EndGameDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _endGameButton;

    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _restartButton.interactable = false;
        _endGameButton.interactable = false;
    }

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _endGameButton.onClick.AddListener(OnEndGameButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _endGameButton.onClick.RemoveListener(OnEndGameButtonClick);
    }

    private void OnDied()
    {
        Time.timeScale = 0;
        _canvasGroup.alpha = 1;
        _restartButton.interactable = true;
        _endGameButton.interactable = true;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnEndGameButtonClick()
    {
        Application.Quit();
    }
}
