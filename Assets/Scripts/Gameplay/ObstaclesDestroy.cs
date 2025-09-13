using UnityEngine;

public class ObstaclesDestroy : MonoBehaviour
{
    [Header("Obstacles")]
    [SerializeField] private GameObject spikes;
    [SerializeField] private GameObject saw;
    [SerializeField] private GameObject cactus;

    private Collider2D spikesColl;
    private Collider2D sawColl;
    private Collider2D cactusColl;

    private Transform spikesTrans;
    private Transform sawTrans;
    private Transform cactusTrans;

    private Vector2 spikesPos;
    private Vector2 sawPos;
    private Vector2 cactusPos;

    void Awake()
    {
        spikesColl = spikes.GetComponent<Collider2D>();
        sawColl = saw.GetComponent<Collider2D>();
        cactusColl = cactus.GetComponent<Collider2D>();

        spikesTrans = spikes.GetComponent<Transform>();
        sawTrans = saw.GetComponent<Transform>();
        cactusTrans = cactus.GetComponent<Transform>();

        spikesPos = spikesTrans.transform.position;
        sawPos = sawTrans.transform.position;
        cactusPos = cactusTrans.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == spikesColl)
        {
            spikes.SetActive(false);
            spikesTrans.position = spikesPos;
        }
        if (collision.collider == sawColl)
        {
            saw.SetActive(false);
            sawTrans.position = sawPos;
        }
        if (collision.collider == cactusColl)
        {
            cactus.SetActive(false);
            cactusTrans.position = cactusPos;
        }
    }
}
