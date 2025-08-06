using System.Collections.Generic;
using UnityEngine;

public abstract class UIHotKeyAbstract : SaiMonoBehaviour
{
    [SerializeField] protected UIHotKeyCtrl hotKeyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHotKeyCtrl();
    }
    protected virtual void LoadHotKeyCtrl()
    {
        if (this.hotKeyCtrl != null) return;
        this.hotKeyCtrl = transform.parent.GetComponent<UIHotKeyCtrl>();
        Debug.Log(transform.name + ": LoadHotKeyCtrl", gameObject);
    }
}
