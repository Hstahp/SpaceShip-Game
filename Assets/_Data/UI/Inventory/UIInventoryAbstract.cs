using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIInventoryAbstract : SaiMonoBehaviour
{
    [Header("Inventory Abstract")]
    [SerializeField] protected UIInventoryController inventoryController;
    public UIInventoryController InventoryController => inventoryController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventoryCtrl();
    }

    protected virtual void LoadInventoryCtrl()
    {
        if (this.inventoryController != null) return;
        this.inventoryController = transform.parent.GetComponent<UIInventoryController>();
        Debug.Log(transform.name + ": LoadInventoryCtrl", gameObject);
    }
}
