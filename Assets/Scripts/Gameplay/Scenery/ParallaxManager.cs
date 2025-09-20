using System.Collections.Generic;
using UnityEngine;

namespace Clase06
{
    public class ParallaxManager : MonoBehaviour
    {
        [SerializeField] private ObstaclesManager obsMng;
        [SerializeField] private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
        [SerializeField] private float parallax = 1;

        private float size = 0;

        private void Start()
        {
            size = spriteRenderers[0].bounds.size.x;
            for (int i = 0; i < spriteRenderers.Count; i++)
            {
                    Vector3 pos = new Vector3(size * i, spriteRenderers[i].transform.position.y, 0);
                    spriteRenderers[i].transform.position = pos;
            }
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
                Vector3 pos = spriteRenderers[i].transform.position;
                pos.x -= (obsMng.obstaclesSpeed.x / parallax) * Time.deltaTime;
                spriteRenderers[i].transform.position = pos;
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
}
// 0 | 1 | 2
// 1 | 2 | 0
// 2 | 0 | 1
// 0 | 1 | 2