using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _gameUICanvas;

    private void Awake()
    {
        _pauseMenu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }


    public void PauseMenu()
    {
        _pauseMenu.SetActive(true);
        _gameUICanvas.SetActive(false);
        Time.timeScale = 0;
    }

    public void ExitPauseMenu()
    {
        _pauseMenu.SetActive(false);
        _gameUICanvas.SetActive(true);
        Time.timeScale = 1;
    }
}
