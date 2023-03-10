using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryHolder : MonoBehaviour
{
    [SerializeField]
    private int InventorySize;
    [SerializeField]
    protected InventorySystem inventorySystem;
    public InventorySystem InventorySystem => inventorySystem;

    protected virtual void Awake()
    {
        inventorySystem = new InventorySystem(InventorySize);
    }

}
