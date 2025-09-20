using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject settingsScreen;

    [SerializeField] private Button continueBtn;
    [SerializeField] private Button settingsBtn;
    [SerializeField] private Button mainMenuBtn;


    [SerializeField] private KeyCode pause = KeyCode.Escape;

    private bool pausing = false;
    private bool onSettings = false;

    void Awake()
    {
        continueBtn.onClick.AddListener(PauseAppear);
        settingsBtn.onClick.AddListener(SettingsAppear);
        mainMenuBtn.onClick.AddListener(MainMenu);
    }

    void Update()
    {
        EscapeUsed();
    }

    private void OnDestroy()
    {
        continueBtn.onClick.RemoveAllListeners();
        settingsBtn.onClick.RemoveAllListeners();
        mainMenuBtn.onClick.RemoveAllListeners();
    }

    public void EscapeUsed()
    {
        if (Input.GetKeyDown(pause) && pausing == false)
        {
            pauseScreen.SetActive(true);
            pausing = true;
            Time.timeScale = 0;
        }

        else if (Input.GetKeyDown(pause) && pausing == true && onSettings == false)
        {
            pauseScreen.SetActive(false);
            pausing = false;
            Time.timeScale = 1;
        }

        else if (Input.GetKeyDown(pause) && pausing == true && onSettings == true)
        {
            settingsScreen.SetActive(false);
            pauseScreen.SetActive(true);
            onSettings = false;
        }
    }

    public void PauseAppear()
    {
        pauseScreen.SetActive(false);
        pausing = false;
        Time.timeScale = 1;
    }

    public void SettingsAppear()
    {
        pauseScreen.SetActive(false);
        settingsScreen.SetActive(true);
        onSettings = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
