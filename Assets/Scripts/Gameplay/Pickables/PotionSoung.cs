using UnityEngine;
using UnityEngine.Audio;

public class PotionSound : MonoBehaviour
{
    [SerializeField] private AudioClip song;
    [SerializeField] private AudioMixer mixer;

    private AudioSource source;

    private float timer;
    public float initTime = 10f;

    private bool music = true;
    private bool goPlay = false;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        timer = initTime;
        music = true;
        goPlay = false;
    }

    private void Update()
    {
        if (goPlay)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                music = true;
                goPlay = false;
                timer = initTime;
            }
        }

        if (music)
        {
            mixer.SetFloat("GameVol", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        music = false;
        mixer.SetFloat("GameVol", -80);
        goPlay = true;
        source.PlayOneShot(song);
    }
}
