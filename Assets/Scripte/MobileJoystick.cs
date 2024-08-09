using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileJoystick : MonoBehaviour
{

    [SerializeField]
    private RectTransform _joystick;
    [SerializeField]
    private RectTransform knob;
    private Vector3 clickedPositon;
    private bool canControl;
    [SerializeField]
    private float moveFactore;
    private Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        HideJoystick();
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl)
        {
            ControleJoytlick();
        }
    }

  public void ClickOnJoytickCllbakc()
    {
         clickedPositon = Input.mousePosition;
        _joystick.position = clickedPositon;
        ShowJoystick();

    }
    public void ShowJoystick()
    {
        _joystick.gameObject.SetActive(true);
        canControl = true;
    }
    public void HideJoystick()
    {
        _joystick.gameObject.SetActive(false);
        canControl = false;

    }
    // Function to control the joystick movement based on user input
    public void ControleJoytlick()
    {
        // Get the current mouse position
        Vector3 CurrentPosition = Input.mousePosition;

        // Calculate the direction vector from the clicked position to the current position
        Vector3 direction = CurrentPosition - clickedPositon;

        // Calculate the magnitude of movement based on direction, move factor, and screen width
        float magnitudeMove = direction.magnitude * moveFactore / Screen.width;

        // Limit the magnitude so the knob doesn't move outside the joystick boundary
        magnitudeMove = MathF.Min(magnitudeMove, _joystick.rect.width / 2);

        // Calculate the movement vector for the knob
        move = direction.normalized * magnitudeMove;

        // Calculate the target position for the knob
        Vector3 targetPositon = clickedPositon + move;

        // Update the knob's position to the target position
        knob.position = targetPositon;

        // If the user releases the mouse button
        if (Input.GetMouseButtonUp(0))
        {
            // Hide the joystick UI and stop controlling it
            HideJoystick();
        }
    }
     public Vector3 GetMove()
    {
        return move;
    }


}
