using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private LoseScreen loseScreen;
    [SerializeField] private GameObject floor;
    [SerializeField] private AudioClip jumpAudio;

    private Rigidbody2D playerRb;
    private Collider2D floorColl;
    private AudioSource playerAudio;

    private bool isOnGround = true;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        floorColl = floor.GetComponent<Collider2D>();
        playerAudio = GetComponent<AudioSource>();
        Physics2D.gravity = playerSO.gravity;
        Physics2D.gravity *= playerSO.gravityModifier;

        gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    private void Update()
    {
        Jumping();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == floorColl)
        {
            isOnGround = true;
        }
        else if (collision.collider == null) {}
        else
        {
            gameObject.SetActive(false);
            Time.timeScale = 0;
            loseScreen.LoseScreenAppear();
        }
    }

    public void Jumping()
    {
        if (Input.GetKey(playerSO.jump) && isOnGround && Time.timeScale == 1)
        {
            playerAudio.PlayOneShot(jumpAudio);
            playerRb.AddForce(Vector2.up * playerSO.jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }
}
