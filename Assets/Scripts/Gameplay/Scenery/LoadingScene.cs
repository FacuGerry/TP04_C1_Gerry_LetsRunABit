using UnityEngine;
using UnityEngine.Audio;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    void Awake()
    {
        mixer.SetFloat("GameVol", 0);
        mixer.SetFloat("Jumping", 0);
    }

}
