using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioClip potionSound;
    [SerializeField] private AudioClip invSound;
    [SerializeField] private AudioClip loseSound;
    [SerializeField] private AudioClip scoreSound;

    public void PlayPotion(AudioSource source)
    {
        source.PlayOneShot(potionSound);
    }

    public void PlayInv(AudioSource source)
    {
        source.PlayOneShot(invSound);
    }

    public void PlayLose(AudioSource source)
    {
        source.PlayOneShot(loseSound);
    }

    public void PlayScore(AudioSource source)
    {
        source.PlayOneShot(scoreSound);
    }
}
