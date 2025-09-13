using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ObjectsSO", order = 1)]
public class ObstaclesSO : ScriptableObject
{
    [Header("Spawn settings")]
    public float spawnTime;
    public float firstSpawn;

    [Header("Speed settings")]
    public Vector2 obstaclesInitSpeed;
    public float speedChanger;
}
