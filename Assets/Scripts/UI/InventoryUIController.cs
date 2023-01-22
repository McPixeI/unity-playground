
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUIController : MonoBehaviour
{
    public GameObject Menu;
    private GameObject player;
    private PlayerLook look;

    void Awake()
    {
        Menu.gameObject.SetActive(false);
    }

    void Update()
    {
        HandleToggleMenu();
        HandleCursor();
    }

    private void HandleToggleMenu()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            Menu.gameObject.SetActive(true);
        }

        if (Menu.gameObject.activeInHierarchy && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Menu.gameObject.SetActive(false);
        }
    }

    private void HandleCursor()
    {
        if (Menu.gameObject.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
