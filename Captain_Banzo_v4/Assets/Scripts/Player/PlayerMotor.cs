using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f;
    public float verticalSpeed = 3f; // Speed for vertical movement
    public float deceleration = 0.98f; // Momentum decay factor

    private Vector3 currentVelocity = Vector3.zero; // Stores current momentum

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void ProcessMove(Vector2 input)
    {
        // Calculate intended movement direction based on input
        Vector3 moveDirection = transform.forward * input.y + transform.right * input.x;

        // Check for vertical movement inputs
        if (Input.GetKey(KeyCode.Space)) // Move up
        {
            moveDirection += transform.up * verticalSpeed;
        }
        if (Input.GetKey(KeyCode.LeftShift)) // Move down
        {
            moveDirection -= transform.up * verticalSpeed;
        }

        // Update currentVelocity based on moveDirection, with speed applied
        if (moveDirection != Vector3.zero)
        {
            currentVelocity = moveDirection * speed;
        }
        else
        {
            // Apply deceleration to create a momentum effect
            currentVelocity *= deceleration;
        }

        // Apply the movement with momentum
        controller.Move(currentVelocity * Time.deltaTime);
    }
}
