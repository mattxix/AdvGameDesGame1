using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;

[RequireComponent(typeof(CharacterController))]
public class FPMovement : MonoBehaviour
{
    public float speed = 10;
    CharacterController controller;
    float h, v;
    public float gravity = -9.8f;
    public float jumpStrength = 10.0f;
    float velocity;
    float gravityMultiplier = 3;

    public float xtraJumpTime = 0.15f;  
    float xtraJumpTimer = 0f;           

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        
        if (IsGrounded())
        {
            xtraJumpTimer = xtraJumpTime;  
        }
        else
        {
            xtraJumpTimer -= Time.deltaTime;
        }

        float moveX = h * speed;
        float moveZ = v * speed;
        Vector3 movement = new Vector3(moveX, 0, moveZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        if (IsGrounded() && velocity < 0)
        {
            velocity = -1;
        }
        else
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;
        }

        movement.y = velocity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        controller.Move(movement);
    }

    public void MoveInput(InputAction.CallbackContext ctx)
    {
        h = ctx.ReadValue<Vector2>().x;
        v = ctx.ReadValue<Vector2>().y;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (xtraJumpTimer <= 0f) return;  // outside the window, no jump

        if (ctx.performed)
        {
            velocity = jumpStrength;
            xtraJumpTimer = 0f;  // consume the window so you can't double-jump
        }
    }

    bool IsGrounded()
    {
        return controller.isGrounded;
    }
}