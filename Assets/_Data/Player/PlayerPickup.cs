using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        ItemCode itemCode = itemPickupable.GetItemCode();
        ItemInventory itemInventory = itemPickupable.ItemController.ItemInventory;
        if (this.playerCtrl.CurrentShip.Inventory.AddItem(itemInventory)) 
        {
            itemPickupable.Picked();
        }
    }
}
