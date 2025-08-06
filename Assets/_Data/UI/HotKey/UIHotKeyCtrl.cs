using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyCtrl : SaiMonoBehaviour
{
    private static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance => instance;
    public List<ItemSlot> itemSlots;
    protected override void Awake()
    {
        if (UIHotKeyCtrl.instance != null) Debug.LogWarning("Only 1 UIHotKeyCtrl allow to exist");
        UIHotKeyCtrl.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemSlots();
    }
    protected virtual void LoadItemSlots()
    {
        if (this.itemSlots.Count > 0) return;
        ItemSlot[] arraySlot = GetComponentsInChildren<ItemSlot>();
        this.itemSlots.AddRange(arraySlot); //chuyển đổi array thành list
        Debug.Log(transform.name + ": LoadItemSlots", gameObject);
    }
}
