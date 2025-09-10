using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] private ObstaclesSO obsSO;

    [Header("Obstacles")]
    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject square;

    private Rigidbody2D circleRb;
    private Rigidbody2D squareRb;

    private void Awake()
    {
        circleRb = circle.GetComponent<Rigidbody2D>();
        squareRb = square.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        InvokeRepeating("ObstaclesSpawn", obsSO.firstSpawn, obsSO.spawnTime);
    }

    void Update()
    {
        ObstaclesSpeed();
    }

    private void ObstaclesSpawn()
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

    private void ObstaclesSpeed()
    {
        if (circle == true)
        {
            circleRb.velocity = Time.deltaTime * new Vector2(-obsSO.obstaclesSpeed, 0);
        }
        else
        {
            circleRb.velocity = Time.deltaTime * new Vector2(0, 0);
        }
        if (square == true)
        {
            squareRb.velocity = Time.deltaTime * new Vector2(-obsSO.obstaclesSpeed, 0);
        }
        else
        {
            squareRb.velocity = Time.deltaTime * new Vector2(0, 0);
        }
        SpeedModifier(obsSO.obstaclesSpeed);
    }

    private void SpeedModifier(float speed)
    {
        speed += obsSO.speedChanger;
    }
}
