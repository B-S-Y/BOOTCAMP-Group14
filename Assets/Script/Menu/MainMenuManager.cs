using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class MainMenuManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip backgroundMusic;

    void Start()
    {
        PlayBackgroundMusic();
    }

    void PlayBackgroundMusic()
    {
        if (audioSource != null && backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    // Button'a atanacak fonksiyonlar:
    public void LoadScene(string sceneName)
    {
        
        SceneManager.LoadScene(sceneName);
    }
    
    public void LoadSceneWithDelay(string sceneName, float delay)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName, 1.5f));
    }
    public void LoadSceneWithDelayWrapper(string sceneName)
    {
        LoadSceneWithDelay(sceneName, 0.5f); // Örneğin 0.5 saniye sonra yükle
    }

    
    
    IEnumerator LoadSceneCoroutine(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }


    public void QuitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}
