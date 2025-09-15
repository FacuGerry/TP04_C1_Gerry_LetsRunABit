using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreSO scoreSO;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AudioClip scoreSound;

    private AudioSource scoreAudio;

    public float score;

    private void Start()
    {
        score = scoreSO.scoreInit;
        scoreAudio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        score += Time.fixedDeltaTime * scoreSO.scoreMult;
        if ((score % 100) < 1 && score > 50)
        {
            scoreAudio.PlayOneShot(scoreSound);
        }
        scoreText.text = score.ToString("0");
    }
}
