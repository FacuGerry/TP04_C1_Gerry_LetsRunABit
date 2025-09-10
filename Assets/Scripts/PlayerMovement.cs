using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    private Rigidbody2D playerRb;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jumping();
    }

    public void Jumping()
    {
        if (Input.GetKeyDown(playerSO.jump))
        {
            playerRb.AddForce(new Vector2(0, playerSO.playerJumpForce), ForceMode2D.Impulse);
        }
    }
}
