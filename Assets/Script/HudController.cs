using TMPro;
using UnityEngine;

public class HudController : MonoBehaviour
{
    public static HudController Instance { get; private set; }

    [SerializeField] private TMP_Text interactionText;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MouseLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }



    public void UpdateInteractionText(string message)
    {
        interactionText.text = message + " (Left Click)";
        interactionText.gameObject.SetActive(true);
    }

    public void ClearInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
}
