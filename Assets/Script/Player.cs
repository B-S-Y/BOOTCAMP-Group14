using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerInput input { get; private set; }
    public PlayerMovement movement { get; private set; }

    private void Awake()
    {
        input = new PlayerInput();
        movement = GetComponent<PlayerMovement>();
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
