using System.Net.Sockets;
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
        scoreText.text = score.ToString("0");
        if (score % 100 >= 0.8f && score % 100 < 1f && score > 10)
        {
            scoreAudio.PlayOneShot(scoreSound);
        }
    }
}
