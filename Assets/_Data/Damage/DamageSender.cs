using UnityEngine;

public class DamageSender : SaiMonoBehaviour
{
    [SerializeField] protected int damage = 1;
    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
        this.CreateImpact();
    }
    protected virtual void CreateImpact()
    {
        string fxName = this.GetImpactFX();
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }
    protected virtual string GetImpactFX()
    {
        return FXSpawner.impactOne;
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
        //  this.DestroyObject();
    }
    //protected virtual void DestroyObject() 
    //{
    //    Destroy(transform.parent.gameObject);
    //}
}
