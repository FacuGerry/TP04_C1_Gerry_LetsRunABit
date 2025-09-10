using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerSO", order = 2)]

public class PlayerSO : ScriptableObject
{
    [Header("Settings")]
    public float playerJumpForce;
    public KeyCode jump = KeyCode.Mouse0;
}
