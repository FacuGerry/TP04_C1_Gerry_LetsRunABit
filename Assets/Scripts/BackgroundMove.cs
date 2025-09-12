using System;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private ObstaclesManager obsMng;
    
    private Rigidbody2D rb;
    private Vector2 startPos;
    private float width;

    void Start()
    {
        startPos = transform.position;
        width = GetComponent<BoxCollider2D>().size.x / 2;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveLeft();
    }

    void Update()
    {
        Restart();
    }

    public void MoveLeft()
    {
        rb.velocity = -obsMng.obstaclesSpeed * Time.fixedDeltaTime;
    }

    public void Restart()
    {
        if (transform.position.x < startPos.x - width)
        {
            transform.position = startPos;
        }
    }
}
