using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreSO scoreSO;
    [SerializeField] private TextMeshProUGUI scoreText;

    public float score;

    private void Start()
    {
        score = scoreSO.scoreInit;
    }

    void FixedUpdate()
    {
        score += Time.fixedDeltaTime * scoreSO.scoreMult;
        scoreText.text = score.ToString("0");
    }
}
