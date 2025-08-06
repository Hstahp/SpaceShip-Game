using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public abstract class DamageReceiver : SaiMonoBehaviour
{
    [Header ("Damage Receiver")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hp = 1;
    [SerializeField] protected int hpMax = 1;
    [SerializeField] protected bool isDead = false;
   public int HP=> hp;
    public int HPMax => hpMax;
    protected override void OnEnable()
    {
        this.Reborn();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.3f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    protected override void Start()
    {
        base.Start();
        this.Reborn();
    }
    public virtual void Reborn()
    {
        this.hp = this.hpMax;
        this.isDead = false;    
    }
    public virtual void Add( int add)
    {
        this.hp += add;
        if(this.hp>this.hpMax) this.hp = this.hpMax;
    }
    public virtual void Deduct(int  deduct)
    {
        this.hp -= deduct;
        if(this.hp<0) this.hp = 0;
        this.CheckIsDead();
    }
    public virtual bool IsDead()
    {
        return this.hp <= 0;    
    }
    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }
    protected abstract void OnDead();
    protected override void ResetValue()
    { 
        base.ResetValue();
        this.Reborn();
    }
}
