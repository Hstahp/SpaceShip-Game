using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletDamSender : DamageSender
{
    [SerializeField] protected BulletController bulletCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }
    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyBullet();
    }
    protected virtual void DestroyBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
}