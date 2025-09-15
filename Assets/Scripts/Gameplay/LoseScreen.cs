using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private ScoreManager scMng;
    [SerializeField] private GameObject loseSC;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button playAgain;
    [SerializeField] private Button mainMenu;

    private void Awake()
    {
        playAgain.onClick.AddListener(PlayAgainClicked);
        mainMenu.onClick.AddListener(MainMenuClicked);
    }

    private void OnDestroy()
    {
        playAgain.onClick.RemoveAllListeners();
        mainMenu.onClick.RemoveAllListeners();
    }

    public void PlayAgainClicked()
    {
        loseSC.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void MainMenuClicked()
    {
        loseSC.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void LoseScreenAppear()
    {
        loseSC.SetActive(true);
        scoreText.text = scMng.score.ToString("0");
    }
    public void LoseScreenDisappear()
    {
        loseSC.SetActive(false);
    }
}
