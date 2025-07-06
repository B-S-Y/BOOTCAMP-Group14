using UnityEngine;

public class Player : Entity
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;




    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
    }


}
