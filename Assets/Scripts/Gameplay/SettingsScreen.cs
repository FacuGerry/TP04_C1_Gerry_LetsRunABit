using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject settingsScreen;

    [Header("Sliders")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [Header("Audios")]
    [SerializeField] private AudioMixer master;
    [SerializeField] private AudioMixer music;
    [SerializeField] private AudioMixer sfx;

    [Header("Button")]
    [SerializeField] private Button backBtn;

    void Awake()
    {
        backBtn.onClick.AddListener(BackClicked);

    }

    private void Update()
    {
        Listener();
    }

    private void OnDestroy()
    {
        backBtn.onClick.RemoveAllListeners();
    }

    public void Listener()
    {
        masterSlider.onValueChanged.AddListener(masterChanged);
        musicSlider.onValueChanged.AddListener(musicChanged);
        sfxSlider.onValueChanged.AddListener(sfxChanged);
    }
    private void masterChanged(float vol)
    {
        master.SetFloat("MasterVol", vol);
    }

    private void musicChanged(float vol)
    {
        music.SetFloat("GameVol", vol);
    }

    private void sfxChanged(float vol)
    {
        sfx.SetFloat("SFXVol", vol);
    }

    public void BackClicked()
    {
        settingsScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
}
