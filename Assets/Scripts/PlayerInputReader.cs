using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    private PlayerInputActions _inputActions;

    public static UnityAction<Vector2> SwipeAction;

    private void Awake()
    {
        if (_inputActions == null)
            _inputActions = new PlayerInputActions();

        _inputActions.Mobile.Swipe.performed += i =>
        {
            if (_inputActions.Mobile.Touch.IsPressed())
                SwipeAction.Invoke(i.ReadValue<Vector2>());
        };
    }

    private void OnEnable()
    {
        EnableInput();
    }

    private void OnDisable()
    {
        DisableInput();
    }

    private void DisableInput()
    {
        _inputActions.Disable();
        _inputActions.Mobile.Disable();
    }

    private void EnableInput()
    {
        _inputActions.Enable();
        _inputActions.Mobile.Enable();
    }
}
