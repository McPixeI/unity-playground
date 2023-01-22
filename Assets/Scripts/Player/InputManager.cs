using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerInput.StandingActions standing;
    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
    private PlayerLook look;
    [SerializeField]
    private GameObject Menu;

    void Awake()
    {
        playerInput = new PlayerInput();
        standing = playerInput.Standing;
        playerMovement = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();
        standing.Jump.performed += ctx => playerMovement.Jump();
    }


    private void FixedUpdate()
    {
        if (!Menu.activeInHierarchy)
        {
            playerMovement.ProcessMovement(standing.Movement.ReadValue<Vector2>());

        }
    }

    private void LateUpdate()
    {
        if (!Menu.activeInHierarchy)
        {
            look.ProcessLook(standing.Look.ReadValue<Vector2>());
        }
    }

    private void OnEnable()
    {
        standing.Enable();
    }

    private void OnDisable()
    {
        standing.Disable();
    }
}
