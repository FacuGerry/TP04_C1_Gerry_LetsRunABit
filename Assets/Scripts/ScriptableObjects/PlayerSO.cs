using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerSO", order = 2)]

public class PlayerSO : ScriptableObject
{
    [Header("Settings")]
    public float jumpForce;
    public float gravityModifier;
    public Vector2 gravity;
    public KeyCode jump = KeyCode.Mouse0;
}
