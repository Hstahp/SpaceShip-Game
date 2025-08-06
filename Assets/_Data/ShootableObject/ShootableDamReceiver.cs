using UnityEngine;
public class ShootableObjectDamReceiver : DamageReceiver
{
    [Header("Shootable Object")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadControoller();
    }
    protected virtual void LoadControoller()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": LoadControoller", gameObject);
    }
    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop();
        this.shootableObjectCtrl.Despawn.DespawnObject();
    }
    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.shootableObjectCtrl.ShootableObject.dropList, dropPos, dropRot);
    }
    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smokeOne;
    }
    public override void Reborn()
    {
        this.hpMax = this.shootableObjectCtrl.ShootableObject.hpMax;
        base.Reborn();
        //Debug.LogWarning("Reborn", gameObject);
    }
}