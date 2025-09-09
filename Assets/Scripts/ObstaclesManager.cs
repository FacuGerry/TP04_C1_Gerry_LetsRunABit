using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] private ObstaclesSO obsSO;

    [Header("Obstacles")]
    public GameObject circle;
    public GameObject square;

    private Collider2D circleColl;
    private Collider2D squareColl;

    private Rigidbody2D circleRb;
    private Rigidbody2D squareRb;
    
    private Transform circleTrans;
    private Transform squareTrans;

    private void Awake()
    {
        circleColl = circle.GetComponent<Collider2D>();
        squareColl = square.GetComponent<Collider2D>();

        circleRb = circle.GetComponent<Rigidbody2D>();
        squareRb = square.GetComponent<Rigidbody2D>();

        circleTrans = circle.GetComponent<Transform>();
        squareTrans = square.GetComponent<Transform>();
    }

    void Start()
    {
        InvokeRepeating("ObstaclesSpawn", obsSO.firstSpawn, obsSO.spawnTime);
    }

    void Update()
    {
        ObstaclesSpeed(obsSO.obstaclesSpeed);
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

    private void ObstaclesSpeed(float speed)
    {
        if (circle == true)
        {
            circleRb.velocity = Time.deltaTime * new Vector2(-speed, 0);
        }
        else
        {
            circleRb.velocity = Time.deltaTime * new Vector2(0, 0);
        }
        if (square == true)
        {
            squareRb.velocity = Time.deltaTime * new Vector2(-speed, 0);
        }
        else
        {
            squareRb.velocity = Time.deltaTime * new Vector2(0, 0);
        }

    }
}
