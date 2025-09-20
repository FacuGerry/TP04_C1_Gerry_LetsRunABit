using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    [SerializeField] private ObstaclesManager obsMng;
    [SerializeField] private List<GameObject> spriteRenderers = new List<GameObject>();

    private float size = 0;

    private float speed;
    [SerializeField] private float parallax;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Awake()
    {
        for (int i = 0; i < spriteRenderers.Count; i++)
        {
            rb = spriteRenderers[i].GetComponent<Rigidbody2D>();
            sr = spriteRenderers[i].GetComponent<SpriteRenderer>();

            size = sr.bounds.size.x;

            Vector3 pos = new Vector3(size * i, spriteRenderers[i].transform.position.y);

            spriteRenderers[i].transform.position = pos;
        }
        speed = obsMng.obstaclesSpeed.x / parallax;
    }

    private void Update()
    {
        MoveBackground();
        FixBackgroundPosition();
    }

    private void MoveBackground()
    {
        for (int i = 0; i < spriteRenderers.Count; i++)
        {
            Vector3 pos = rb.velocity;
            pos.x -= speed * Time.deltaTime;
            rb.velocity = pos;
        }
    }

    private void FixBackgroundPosition()
    {
        for (int i = 0; i < spriteRenderers.Count; i++)
        {
            if (spriteRenderers[i].transform.position.x < -size)
            {
                int prevIndex = i - 1;
                if (prevIndex < 0)
                    prevIndex = spriteRenderers.Count - 1;

                Vector3 pos = spriteRenderers[i].transform.position;
                pos.x = spriteRenderers[prevIndex].transform.position.x + size;
                spriteRenderers[i].transform.position = pos;
            }
        }
    }
}
// 0 | 1 | 2
// 1 | 2 | 0
// 2 | 0 | 1
// 0 | 1 | 2