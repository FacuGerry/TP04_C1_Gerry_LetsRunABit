using System;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private ObstaclesManager obsMng;
    public float parallaxFX;

    private Rigidbody2D backgroundRb;
    private Vector2 startPos;
    private float width;

    void Awake()
    {
        backgroundRb = GetComponent<Rigidbody2D>();

        startPos = transform.position;
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
        backgroundRb.velocity = (-obsMng.obstaclesSpeed / parallaxFX) * Time.fixedDeltaTime;
    }

    public void Restart()
    {
        if (transform.position.x < startPos.x - width)
        {
            transform.position = startPos;
        }
    }
}
