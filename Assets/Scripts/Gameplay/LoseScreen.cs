using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    public void LoseScreenAppear()
    {
        gameObject.SetActive(true);
    }
    public void LoseScreenDisappear()
    {
        gameObject.SetActive(false);
    }
}
