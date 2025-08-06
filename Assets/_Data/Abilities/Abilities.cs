using Unity.VisualScripting;
using UnityEngine;

public class Abilities : SaiMonoBehaviour
{
    [Header("Abilities")]
    [SerializeField] protected AbilityObjectCtrl abilityObjectCtrl;
    public AbilityObjectCtrl AbilityObjectCtrl  => abilityObjectCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityObjectCtrl();
    }
    protected virtual void LoadAbilityObjectCtrl()
    {
        if (this.abilityObjectCtrl != null) return;
        this.abilityObjectCtrl = transform.parent.GetComponent<AbilityObjectCtrl>();
        Debug.Log(transform.name + ": LoadAbilityObjectCtrl", gameObject);
    }
}
