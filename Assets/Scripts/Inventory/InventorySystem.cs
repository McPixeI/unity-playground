using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem
{
    [SerializeField]
    private List<InventorySlot> inventorySlots;
    public List<InventorySlot> InventorySlots => inventorySlots;
    public int InventorySize => InventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;
    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(InventoryItemData item, int amount)
    {

        // Checks if item exists in inventory
        if (ContainsItem(item, out List<InventorySlot> slots))
        {
            foreach (var slot in slots)
            {
                if (slot.RoomLeftInStack(amount))
                {
                    slot.AddToStack(amount);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }

        }
        // If not, get first available slot
        else if (HasFreeSlot(out InventorySlot freeSlot))
        {
            Debug.Log("has free slot");
            freeSlot.UpdateInventorySlot(item, amount);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }

        return false;

    }

    public bool ContainsItem(InventoryItemData item, out List<InventorySlot> slots)
    {
        slots = InventorySlots.Where(i => i.ItemData == item).ToList();
        return slots.Count > 0 ? true : false;
    }

    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        Debug.Log(freeSlot);
        return freeSlot == null ? false : true;
    }
}
