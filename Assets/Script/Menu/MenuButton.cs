using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButton : MonoBehaviour
{


    // Update is called once per frame
    [SerializeField] private Animator animator;
	[SerializeField] private string sceneToLoad;
	[SerializeField] private MainMenuManager mainMenuManager;
    
        private bool isClicked = false;
    
        public void OnButtonClick()
        {
	        if (isClicked) return;
	        isClicked = true;

	        animator.SetTrigger("Selected"); // Eğer Selected → Pressed geçişi varsa bu tetiklenir
	        animator.SetTrigger("Pressed");  // Pressed animasyonunu oynatır

        }

        public void OnAnimationFinished()
        {
	        if (isClicked)
		        mainMenuManager.LoadScene(sceneToLoad);
        }

}
