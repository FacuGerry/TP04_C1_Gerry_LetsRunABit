using TMPro;
using UnityEngine;

public class InvMng : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    public float timer = 0;
    public float maxTime = 5f;

    public bool goPlay = false;

    void Awake()
    {
        goPlay = false;
        timer = maxTime;
    }

    private void FixedUpdate()
    {
        if (goPlay)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = maxTime;
                goPlay = false;
            }
        }
    }
}
