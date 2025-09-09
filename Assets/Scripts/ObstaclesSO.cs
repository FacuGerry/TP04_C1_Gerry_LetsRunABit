using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ObjectsSO", order = 1)]
public class ObstaclesSO : ScriptableObject
{
    [Header("Settings")]
    public float spawnTime;
    public float firstSpawn;
    public int obstaclesSpeed;

    
}
