using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ScoreSO", order = 3)]

public class ScoreSO : ScriptableObject
{
    public float scoreInit;
    public float scoreMult;
    public float scoreXtra;
}
