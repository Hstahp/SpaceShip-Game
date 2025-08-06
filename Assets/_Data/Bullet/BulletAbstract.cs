using UnityEngine;

public class BulletAbstract : SaiMonoBehaviour
{
    [Header ("Bullet Abstract")]
    [SerializeField] protected BulletController bulletCtrl;
    public BulletController BulletController { get => bulletCtrl;  }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        //this.LoadDamageReceiver();
        this.LoadBulletController();
    }
    protected virtual void LoadBulletController()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletController>();
       // Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }
    protected virtual void LoadDamageReceiver()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject); 
    }
}
