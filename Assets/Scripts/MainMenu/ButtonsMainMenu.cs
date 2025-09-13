using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsMainMenu : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button creditsBtn;
    [SerializeField] private Button exitBtn;

    void Start()
    {
        playBtn.onClick.AddListener(OnPlayClicked);
        creditsBtn.onClick.AddListener(OnCreditsClicked);
        exitBtn.onClick.AddListener(OnExitClicked);
    }

    private void OnDestroy()
    {
        playBtn.onClick.RemoveAllListeners();
        creditsBtn.onClick.RemoveAllListeners();
        exitBtn.onClick.RemoveAllListeners();
    }

    public void OnPlayClicked()
    {
        SceneManager.LoadScene("Game");
    }

    private void OnExitClicked()
    {
        Application.Quit();
    }

    private void OnCreditsClicked()
    {

    }

}
