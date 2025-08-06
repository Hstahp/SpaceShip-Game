using UnityEngine;

public abstract class ItemAbstract : SaiMonoBehaviour
{
    [Header("Junk Abstract")]
    [SerializeField] protected ItemController itemCtrl;
    public ItemController ItemController  => itemCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemController();
    }
    protected virtual void LoadItemController()
    {
        if (this.itemCtrl != null) return;
        this.itemCtrl = transform.parent.GetComponent<ItemController>();
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

}
