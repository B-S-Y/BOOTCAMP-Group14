using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerMovement1 : MonoBehaviour
{
    private Player player;
    private PlayerInput input;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject point;
    public CharacterController charController { get; private set; }


    [Header("Movement")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;


    private float speed;
    private float verticalVelocity;

    public Vector2 moveInput { get; private set; }
    private Vector3 movementDirection;

    public bool isRunning { get; private set; }

    private float stamina = 100f;
    private float staminaInterval = 20f; // Değer azaldıkça koşu süresi artar


    [SerializeField] private Image staminaBar;



    private void Start()
    {
        player = GetComponent<Player>();
        charController = GetComponent<CharacterController>();

        speed = walkSpeed;
        InputEvents();
    }

    void Update()
    {
        ApplyMovement();
        ApplyGravity();
        DecreasesStamina();

    }

    private void ApplyMovement()
    {
        agent.destination = point.transform.position;
        movementDirection = transform.right * moveInput.x + transform.forward * 1.5f; //moveInput.y;
        ApplyGravity();
        if (movementDirection.magnitude > 0)
        {
            player.effects.PlayFootStepSFX();

            charController.Move(movementDirection * speed * Time.deltaTime);
            Effects();
        }
    }



    private void Effects()
    {
        player.cam.headBob.HeadBob(speed, isRunning ? 0.11f : 0.07f);
        player.cam.cameraFov.SetCameraFov(isRunning ? 75f : 60f);
    }

    private void ApplyGravity()
    {
        if (!charController.isGrounded)
        {
            verticalVelocity -= 9.81f * Time.deltaTime;
            movementDirection.y = verticalVelocity;
        }
        else
            verticalVelocity = -.5f;
    }

    private void DecreasesStamina()
    {
        if (isRunning && stamina > 0)
        {
            stamina -= Time.deltaTime * staminaInterval; // Stamina azalır
            if (stamina <= 0)
            {
                isRunning = false;
                speed = walkSpeed;

            }
        }
        else if (!isRunning && stamina < 100f)
        {
            stamina += Time.deltaTime * staminaInterval * 0.5f; // Stamina yeniden dolar
        }
        stamina = Mathf.Clamp(stamina, 0, 100f); // Stamina değerini 0-100 arasında tutar

        staminaBar.fillAmount = stamina / 100f;
    }
    private void InputEvents()
    {
        input = player.input;

        input.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += ctx =>
        {
            Invoke(nameof(StopFootstepSound), 0.05f);
            moveInput = Vector2.zero;
        };

        input.Player.Sprint.performed += context =>
        {
            isRunning = true;
            speed = runSpeed;

        };
        input.Player.Sprint.canceled += context =>
        {
            isRunning = false;
            speed = walkSpeed;
            Invoke(nameof(StopFootstepSound), 0.05f);
        };
    }

    private void StopFootstepSound()
    {
        player.effects.StopFootStepSFX();
    }

    public Vector3 GetMovementDirection() => movementDirection;
}
