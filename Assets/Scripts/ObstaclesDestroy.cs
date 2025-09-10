using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesDestroy : MonoBehaviour
{
    [Header("Obstacles")]
    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject square;

    private Collider2D circleColl;
    private Collider2D squareColl;

    private Transform circleTrans;
    private Transform squareTrans;

    void Awake()
    {
        circleColl = circle.GetComponent<Collider2D>();
        squareColl = square.GetComponent<Collider2D>();

        circleTrans = circle.GetComponent<Transform>();
        squareTrans = square.GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == circleColl)
        {
            circle.SetActive(false);
            circleTrans.position = new Vector2(11, 0);
        }
        if (collision.collider == squareColl)
        {
            square.SetActive(false);
            squareTrans.position = new Vector2(11, 0);
        }
    }
}
