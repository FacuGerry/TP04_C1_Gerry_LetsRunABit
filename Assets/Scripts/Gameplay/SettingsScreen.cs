using System;
using TMPro;
using UnityEngine;
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

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI masterText;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI sfxText;

    [Header("Audios")]
    [SerializeField] private AudioBehaviour master;
    [SerializeField] private AudioBehaviour music;
    [SerializeField] private AudioBehaviour sfx;

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

    private void sfxChanged(float vol)
    {

    }

    private void musicChanged(float vol)
    {

    }

    private void masterChanged(float vol)
    {

    }

    public void BackClicked()
    {
        settingsScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
}
