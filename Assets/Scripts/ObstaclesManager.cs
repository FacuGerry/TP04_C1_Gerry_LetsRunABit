using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] private ObstaclesSO obsSO;

    [Header("Obstacles")]
    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject square;

    private Rigidbody2D circleRb;
    private Rigidbody2D squareRb;

    public Vector2 obstaclesSpeed;

    private void Awake()
    {
        obstaclesSpeed = obsSO.obstaclesInitSpeed;
        circleRb = circle.GetComponent<Rigidbody2D>();
        squareRb = square.GetComponent<Rigidbody2D>();
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

        if (dice < 0.5f)
        {
            circle.SetActive(true);
        }
        if (dice >= 0.5f)
        {
            square.SetActive(true);
        }
    }

    public void ObstaclesSpeed()
    {
        if (circle == true)
        {
            circleRb.velocity = Time.fixedDeltaTime * -obstaclesSpeed;
        }
        else
        {
            circleRb.velocity = Time.fixedDeltaTime * new Vector2(0, 0);
        }
        if (square == true)
        {
            squareRb.velocity = Time.fixedDeltaTime * -obstaclesSpeed;
        }
        else
        {
            squareRb.velocity = Time.fixedDeltaTime * new Vector2(0, 0);
        }
        SpeedModifier();
    }

    public void SpeedModifier()
    {
        obstaclesSpeed += new Vector2(obsSO.speedChanger, 0);
    }
}
