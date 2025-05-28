using UnityEngine;

public class PlayerMovementJump : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintMultiplier = 1.5f;

    public float jumpForce = 7f;          
    public float gravity = -9.81f;        
    public float groundY = 1f;            

    private float verticalVelocity = 0f;  
    public bool isGrounded = true;       

    void Update()
    {
        // Get horizontal movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        float speed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= sprintMultiplier;
        }

        // Horizontal movement
        Vector3 horizontalMove = moveDirection * speed * Time.deltaTime;

        // Jump input & logic
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
            isGrounded = false;
        }

        // Apply gravity to vertical velocity
        verticalVelocity += gravity * Time.deltaTime;

        // Calculate vertical movement this frame
        float verticalMove = verticalVelocity * Time.deltaTime;

        // Calculate new position
        Vector3 newPosition = transform.position + horizontalMove + new Vector3(0f, verticalMove, 0f);

        // Check for ground collision
        if (newPosition.y <= groundY)
        {
            newPosition.y = groundY;
            verticalVelocity = 0f;
            isGrounded = true;
        }

        transform.position = newPosition;
    }
}
