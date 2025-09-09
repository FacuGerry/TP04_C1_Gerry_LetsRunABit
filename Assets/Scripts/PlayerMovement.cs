using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Velocity inicial + variacion segun el tiempo
    [Header("Speed")]
    [SerializeField] private float playerInitialSpeed;
    [SerializeField] private float playerExtraSpeed;
    [Header("Jump settings")]
    [SerializeField] private float playerJumpForce;
    [SerializeField] KeyCode jump = KeyCode.Mouse0;

    private Rigidbody2D playerRb;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.velocity = new Vector2(playerInitialSpeed, 0);
    }

    void Update()
    {
        playerRb.AddForce(new Vector2(playerExtraSpeed, 0).normalized, ForceMode2D.Force);
        Jumping();
    }

    public void Jumping()
    {
        if (Input.GetKeyDown(jump))
        {
            playerRb.AddForce(new Vector2(0, playerJumpForce), ForceMode2D.Impulse);
        }
    }

}
