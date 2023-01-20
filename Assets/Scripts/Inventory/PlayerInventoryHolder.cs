
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryHolder : InventoryHolder
{
    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            Debug.Log("open inventory");
            OnDynamicInventoryDisplayRequested?.Invoke(inventorySystem);
        }
    }
}
