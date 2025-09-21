using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Sounds soundMng;
    [SerializeField] private ScoreSO scoreSO;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI invTimeText;
    [SerializeField] private GameObject timerText;
    [SerializeField] private InvMng invMng;

    private AudioSource source;

    public float score;

    private void Start()
    {
        score = scoreSO.scoreInit;
        source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        score += Time.fixedDeltaTime * scoreSO.scoreMult;
        if ((score % 100) < 1 && score > 50)
        {
            soundMng.PlayScore(source);
        }
        scoreText.text = score.ToString("0");

        timerText.SetActive(invMng.goPlay);
        invTimeText.text = invMng.timer.ToString("0");
    }
}
