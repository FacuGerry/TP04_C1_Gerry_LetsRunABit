using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsMainMenu : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button creditsBtn;
    [SerializeField] private Button exitBtn;
    [SerializeField] private Button goBackBtn;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject credits;

    void Awake()
    {
        playBtn.onClick.AddListener(OnPlayClicked);
        creditsBtn.onClick.AddListener(OnCreditsClicked);
        exitBtn.onClick.AddListener(OnExitClicked);
        goBackBtn.onClick.AddListener(OnBackClicked);
        Time.timeScale = 1;
    }

    private void OnDestroy()
    {
        playBtn.onClick.RemoveAllListeners();
        creditsBtn.onClick.RemoveAllListeners();
        exitBtn.onClick.RemoveAllListeners();
        goBackBtn.onClick.RemoveAllListeners();
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
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void OnBackClicked()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }

}
