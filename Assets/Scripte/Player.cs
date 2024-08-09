using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  

    // Reference to the MobileJoystick component used for player input
    [SerializeField]
    private MobileJoystick joysick;

   
    // Reference to the CharacterController component that handles movement
    private CharacterController characterController;

    

    // Speed at which the player moves
    [SerializeField]
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Get the CharacterController component attached to the GameObject
        characterController = GetComponent<CharacterController>();

        
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player movement each frame
        MangeMovement();
    }

    // Function to manage player movement based on joystick input
    private void MangeMovement()
    {
        // Get the movement vector from the joystick and scale it by moveSpeed, time, and screen width
        Vector3 moveVector = joysick.GetMove() * moveSpeed * Time.deltaTime / Screen.width;

        // Map the vertical movement to the Z axis (forward/backward in Unity)
        moveVector.z = moveVector.y;

        // Set the Y axis to 0 to prevent movement in the vertical direction
        moveVector.y = 0;

        // Move the player using the CharacterController component
        characterController.Move(moveVector);

      
    }
}
