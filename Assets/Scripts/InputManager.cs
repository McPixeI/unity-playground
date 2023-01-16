using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.StandingActions standing;
    private PlayerMovement playerMovement;
    private PlayerLook look;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerInput = new PlayerInput();
        standing = playerInput.Standing;
        playerMovement = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();
        standing.Jump.performed += ctx => playerMovement.Jump();
    }

    private void FixedUpdate()
    {
        playerMovement.ProcessMovement(standing.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(standing.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        standing.Enable();
    }

    private void OnJump()
    {
        Debug.Log("on jump");
    }

    private void OnDisable()
    {
        standing.Disable();
    }
}
