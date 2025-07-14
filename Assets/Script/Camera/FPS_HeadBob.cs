using System;
using UnityEngine;

public class FPS_HeadBob : MonoBehaviour
{
    private Player player;
    private Camera cam;


    private float defaultYPos;
    private float timer;

    void Start()
    {
        player = GetComponentInParent<Player>();
        cam = GetComponent<Camera>();
        defaultYPos = cam.transform.localPosition.y;
    }

    public void HeadBob(float bobSpeed, float bobAmount)
    {
        if (!player.movement.charController.isGrounded) return;

        if (Mathf.Abs(player.movement.GetMovementDirection().x) > 0.1f || Mathf.Abs(player.movement.GetMovementDirection().z) > 0.1f)
        {
            timer += Time.deltaTime * (bobSpeed + 15f * (player.movement.isRunning ? 1.5f : 1f));
            float newY = defaultYPos + Mathf.Sin(timer) * bobAmount;

            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, newY, cam.transform.localPosition.z);
        }
        else
        {
            // Hareket etmiyorsa kamerayı eski pozisyona geri getir
            timer = 0f;
            Vector3 pos = cam.transform.localPosition;
            pos.y = Mathf.Lerp(pos.y, defaultYPos, Time.deltaTime * bobSpeed);
            cam.transform.localPosition = pos;
        }
    }
}
