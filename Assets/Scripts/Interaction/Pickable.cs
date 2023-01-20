using UnityEngine;

public class Pickable : Interactable
{
    private GameObject player;
    private InventoryItemData itemData;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        itemData = gameObject.GetComponent<ItemController>().item;
    }

    protected override void Interact()
    {
        var inventory = player.GetComponent<InventoryHolder>();
        if (!inventory) return;

        if (inventory.InventorySystem.AddToInventory(itemData, 1))
        {
            Destroy(this.gameObject);
        }
    }
}
