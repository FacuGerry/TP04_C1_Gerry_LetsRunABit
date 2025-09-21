using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] private ObstaclesSO obsSO;

    [Header("Obstacles")]
    [SerializeField] private GameObject spike;
    [SerializeField] private GameObject saw;
    [SerializeField] private GameObject cactus;

    private Rigidbody2D spikeRb;
    private Rigidbody2D sawRb;
    private Rigidbody2D cactusRb;

    public Collider2D spikeColl;
    public Collider2D sawColl;
    public Collider2D cactusColl;

    public Vector2 obstaclesSpeed;

    private void Awake()
    {
        obstaclesSpeed = obsSO.obstaclesInitSpeed;
        spikeRb = spike.GetComponent<Rigidbody2D>();
        sawRb = saw.GetComponent<Rigidbody2D>();
        cactusRb = cactus.GetComponent<Rigidbody2D>();

        spikeColl = spike.GetComponent<Collider2D>();
        sawColl = saw.GetComponent<Collider2D>();
        cactusColl = cactus.GetComponent<Collider2D>();
    }

    void Start()
    {
        InvokeRepeating("ObstaclesSpawn", obsSO.firstSpawn, obsSO.spawnTime);
    }

    void FixedUpdate()
    {
        ObstaclesSpeed();
    }

    public void ObstaclesSpawn()
    {
        float dice = Random.value;

        if (dice < 0.33f)
        {
            spike.SetActive(true);
        }
        else if (dice >= 0.33f && dice < 0.66f)
        {
            saw.SetActive(true);
        }
        else if (dice >= 0.66f)
        {
            cactus.SetActive(true);
        }
    }

    public void ObstaclesSpeed()
    {
        if (spike == true)
        {
            spikeRb.velocity = Time.fixedDeltaTime * -obstaclesSpeed;
        }
        else
        {
            spikeRb.velocity = Time.fixedDeltaTime * new Vector2(0, 0);
        }

        if (saw == true)
        {
            sawRb.velocity = Time.fixedDeltaTime * -obstaclesSpeed;
        }
        else
        {
            sawRb.velocity = Time.fixedDeltaTime * new Vector2(0, 0);
        }

        if (cactus == true)
        {
            cactusRb.velocity = Time.fixedDeltaTime * -obstaclesSpeed;
        }
        else
        {
            cactusRb.velocity = Time.fixedDeltaTime * new Vector2(0, 0);
        }

        SpeedModifier();
    }

    public void SpeedModifier()
    {
        obstaclesSpeed += new Vector2(obsSO.speedChanger, 0);
    }
}
