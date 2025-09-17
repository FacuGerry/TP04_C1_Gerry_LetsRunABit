using UnityEngine;

public class ObstaclesDestroy : MonoBehaviour
{
    [Header("Obstacles")]
    [SerializeField] private GameObject spikes;
    [SerializeField] private GameObject saw;
    [SerializeField] private GameObject cactus;

    private Transform spikesTrans;
    private Transform sawTrans;
    private Transform cactusTrans;

    private Vector2 spikesPos;
    private Vector2 sawPos;
    private Vector2 cactusPos;

    public float maxPos;

    void Awake()
    {
        spikesTrans = spikes.GetComponent<Transform>();
        sawTrans = saw.GetComponent<Transform>();
        cactusTrans = cactus.GetComponent<Transform>();

        spikesPos = spikesTrans.transform.position;
        sawPos = sawTrans.transform.position;
        cactusPos = cactusTrans.transform.position;
    }

    private void Update()
    {
        if (spikesTrans.position.x < maxPos)
        {
            spikes.SetActive(false);
            spikesTrans.position = spikesPos;
        }
        if (sawTrans.position.x < maxPos)
        {
            saw.SetActive(false);
            sawTrans.position = sawPos;
        }
        if (cactusTrans.position.x < maxPos)
        {
            cactus.SetActive(false);
            cactusTrans.position = cactusPos;
        }
    }
}
