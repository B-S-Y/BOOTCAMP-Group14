using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Toggle fullscreenToggle;
    [SerializeField] AudioSource musicSource;
    void Start()
    {
        // Varsayılan ses seviyesi
        float defaultVolume = 1f;
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        fullscreenToggle.onValueChanged.AddListener(OnFullscreenToggled);

        volumeSlider.value = defaultVolume;
        musicSource.volume = defaultVolume;
        
        
        
        // Varsayılan tam ekran
        bool defaultFullscreen = true;
        fullscreenToggle.isOn = defaultFullscreen;
        Screen.fullScreen = defaultFullscreen;

        
    }

    public void OnVolumeChanged(float value)
    {
        if (musicSource != null)
        {
            musicSource.volume = value;
        }
        else
        {
            Debug.Log("source boş");
        }
    }

    public void OnFullscreenToggled(bool isFullscreen)
    {
        Debug.Log("Toggle changed: " + isFullscreen);
        Screen.fullScreen = isFullscreen;
    }



    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}