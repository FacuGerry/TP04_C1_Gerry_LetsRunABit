using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Vector2 camLimits;
    private Rigidbody2D camRb;

    void Start()
    {
        camRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (camRb.position.y < camLimits.y)
        {
            camRb.position = new Vector2(camRb.position.x, camLimits.y);
        }
    }
}
