using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{

    private Vector2 m_movePosition = Vector2.zero;
    private bool interactPressed = false;
    private bool submitPressed = false;

    public static InputManager Instance { get; private set; }


   
    private void Awake()
    {
        if (Instance != null)
            Debug.Log("There is more than one InputManager in the scene");
        
        Instance = this;
    }

    public void MovePressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            m_movePosition = context.ReadValue<Vector2>();
        }
        else
        {
            m_movePosition = context.ReadValue<Vector2>();
        }
    }

    public void InteractPressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            interactPressed = true;
        }
        else if(context.canceled)
        {
            interactPressed = false;
        }
    }

    public void SubmitPressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
           submitPressed = true;
        }
        else if (context.canceled)
        {
            submitPressed = false;
        }
    }

    public Vector2 GetMovePosition()
    {
        return m_movePosition;
    }

    public bool GetInteractPressed()
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

    public bool GetSubmitPressed()
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
