using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerInput input { get; private set; }
    public PlayerMovement movement { get; private set; }
    public PlayerEffects effects { get; private set; }
    public FPS_Camera cam { get; private set; }

    private void Awake()
    {
        input = new PlayerInput();
        movement = GetComponent<PlayerMovement>();
        effects = GetComponent<PlayerEffects>();
        cam = GetComponentInChildren<FPS_Camera>();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }


}
