using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ObjectsSO", order = 1)]
public class ObstaclesSO : ScriptableObject
{
    [Header("Spawn settings")]
    public float spawnTime;
    public float firstSpawn;

    [Header("Speed settings")]
    public float speedChanger;
    public float obstaclesSpeed;
    public float firstSpeedChange;
    public float speedChangeTime;

}
