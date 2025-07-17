using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Animator[] lightsAnim;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Invoke(nameof(SetLightsActive), 10f);
    }


    public void SetLightsActive()
    {
        foreach (var anim in lightsAnim)
        {
            if (anim != null)
            {
                anim.SetBool("Alarm", true);
                AudioManager.instance.PlaySFX(2, PlayerManager.instance.player.transform);
            }
        }
    }




}
