using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private ObstaclesManager obsMng;
    [SerializeField] private PickableMng pickMng;

    [Header("Player")]
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private LoseScreen loseScreen;
    [SerializeField] private GameObject floor;
    [SerializeField] private AudioClip jumpAudio;
    [SerializeField] private AnimationsPlayer animations;
    [SerializeField] private TextMeshProUGUI life;

    [Header("Xtra")]
    [SerializeField] private Sounds soundMng;
    [SerializeField] private InvMng invMng;

    private Rigidbody2D playerRb;
    private Collider2D floorColl;
    private AudioSource source;

    private bool isOnGround = true;
    public int lives = 1;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        floorColl = floor.GetComponent<Collider2D>();
        source = GetComponent<AudioSource>();
        Physics2D.gravity = playerSO.gravity;
        Physics2D.gravity *= playerSO.gravityModifier;

        gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        Jumping();
        life.text = lives.ToString("0");
        if (lives == 0)
        {
            loseScreen.LoseScreenAppear();
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == floorColl)
        {
            isOnGround = true;
            animations.Run();
        }
        
        if ((collision.collider == obsMng.spikeColl || collision.collider == obsMng.sawColl || collision.collider == obsMng.cactusColl) && invMng.goPlay == false) 
        {
            lives -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == pickMng.potionColl)
        {
            pickMng.PickableRestartPosOnTouchPotion();
            lives += 1;
            soundMng.PlayPotion(source);
        }

        if (collision == pickMng.invColl)
        {
            pickMng.PickableRestartPosOnTouchInv();
            soundMng.PlayInv(source);
            invMng.goPlay = true;
        }
    }

    public void Jumping()
    {
        if (Input.GetKey(playerSO.jump) && isOnGround && Time.timeScale == 1)
        {
            isOnGround = false;
            source.PlayOneShot(jumpAudio);
            playerRb.AddForce(Vector2.up * playerSO.jumpForce, ForceMode2D.Impulse);
            animations.Jumping();
        }
    }
}
