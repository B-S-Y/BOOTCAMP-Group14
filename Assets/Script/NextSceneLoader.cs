using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
   private void Start() {
       StartCoroutine(LoadSceneCoroutine("PuzzleScene"));
   }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        // (İsteğe bağlı: Loading ekranı göster)
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Sahne yüklense bile otomatik aktive olmasın
        asyncLoad.allowSceneActivation = false;

        // %90'a kadar yüklenmesini bekle
        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }

        // (İsteğe bağlı: küçük bekleme veya "Press any key to continue" gibi bir şey)

        // Şimdi sahneyi aktive et
        asyncLoad.allowSceneActivation = true;
    }
}
