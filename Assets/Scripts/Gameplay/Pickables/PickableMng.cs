using UnityEngine;

public class PickableMng : MonoBehaviour
{
    [SerializeField] private ObstaclesSO obsSO;

    [Header("Obstacles")]
    public GameObject potion;
    public GameObject invincible;

    private Rigidbody2D potionRb;
    private Rigidbody2D invRb;

    private Transform potionTrans;
    private Transform invTrans;
    
    public Collider2D potionColl;
    public Collider2D invColl;
    
    private Vector2 potionPos;
    private Vector2 invPos;

    public Vector2 obstaclesSpeed;
    public Vector2 modifier = Vector2.one;

    [SerializeField] private float timeSpawn;
    [SerializeField] private float timeSpawnBetweenItems;

    public float maxPos;

    private void Awake()
    {
        obstaclesSpeed = obsSO.obstaclesInitSpeed;
        potionRb = potion.GetComponent<Rigidbody2D>();
        invRb = invincible.GetComponent<Rigidbody2D>();

        potionTrans = potion.GetComponent<Transform>();
        invTrans = invincible.GetComponent<Transform>();

        potionColl = potion.GetComponent<Collider2D>();
        invColl = invincible.GetComponent<Collider2D>();

        potionPos = potionTrans.transform.position;
        invPos = invTrans.transform.position;
    }

    void Start()
    {
        InvokeRepeating(nameof(PickableSpawn), timeSpawn, timeSpawnBetweenItems);
    }

    void FixedUpdate()
    {
        PickableSpeed();
        PickableRestartPos();
    }

    public void PickableSpawn()
    {
        float dice = Random.value;
        Debug.Log(dice);

        if (dice < 0.5f)
        {
            potion.SetActive(true);
        }
        else
        {
            invincible.SetActive(true);
        }
    }

    public void PickableSpeed()
    {
        if (potion == true)
        {
            potionRb.velocity = Time.fixedDeltaTime * (-obstaclesSpeed / modifier);
        }
        else
        {
            potionRb.velocity = Time.fixedDeltaTime * new Vector2(0, 0);
        }

        if (invincible == true)
        {
            invRb.velocity = Time.fixedDeltaTime * (-obstaclesSpeed / modifier);
        }
        else
        {
            invRb.velocity = Time.fixedDeltaTime * new Vector2(0, 0);
        }
    }

    public void PickableRestartPos()
    {
        if (potionTrans.position.x < maxPos)
        {
            potion.SetActive(false);
            potionTrans.position = potionPos;
        }
        if (invTrans.position.x < maxPos)
        {
            invincible.SetActive(false);
            invTrans.position = invPos;
        }
    }

    public void PickableRestartPosOnTouchPotion()
    {
            potion.SetActive(false);
            potionTrans.position = potionPos;
    }

    public void PickableRestartPosOnTouchInv()
    {
            invincible.SetActive(false);
            invTrans.position = invPos;
    }
}
