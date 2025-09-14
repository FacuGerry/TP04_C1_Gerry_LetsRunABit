using TMPro;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private ScoreManager scMng;
    [SerializeField] private GameObject loseSC;
    [SerializeField] private TextMeshProUGUI scoreText;

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
