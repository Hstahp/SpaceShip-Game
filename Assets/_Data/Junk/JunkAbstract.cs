using UnityEngine;

public abstract class JunkAbstract : SaiMonoBehaviour
{
    [Header("Junk Abstract")]
    [SerializeField] protected JunkController junkCtrl;
    public JunkController JunkController { get => junkCtrl; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }
    protected virtual void LoadJunkController()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkController>();
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }
}
