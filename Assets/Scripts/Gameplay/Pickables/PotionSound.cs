using UnityEngine;
using UnityEngine.Audio;

public class PicakbleSound : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMvmnt;
    [SerializeField] private AudioClip song;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private GameObject player;
    private Collider2D playerColl;

    private AudioSource source;

    private float timer;
    public float initTime = 9.5f;

    private bool music = true;
    private bool goPlay = false;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        playerColl = player.GetComponent<Collider2D>();
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
            mixer.SetFloat("Jumping", 0);
            playerMvmnt.isInv = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == playerColl)
        {
            music = false;
            goPlay = true;
            mixer.SetFloat("GameVol", -80);
            mixer.SetFloat("Jumping", -80);
            source.PlayOneShot(song);
        }
    }
}
