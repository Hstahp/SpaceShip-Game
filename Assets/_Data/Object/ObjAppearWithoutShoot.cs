using UnityEngine;

public class ObjAppearWithoutShoot : ShootableObjectAbstarct, IObjAppearObserver
{
    [Header("Without Shoot")]
    [SerializeField] protected ObjAppearing objAppearing;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterAppearEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjAppearing();
    }
    protected virtual void LoadObjAppearing()
    {
        if (this.objAppearing != null) return;
        this.objAppearing = transform.GetComponent<ObjAppearing>();
        Debug.Log(transform.name + ": LoadObjAppearing", gameObject);
    }
    protected virtual void RegisterAppearEvent()
    {
        this.objAppearing.ObserverAdd(this);
    }

    public void OnAppearStart()
    {
        this.shootableObjectCtrl.ObjShooting.gameObject.SetActive(false);
        this.shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        this.shootableObjectCtrl.ObjShooting.gameObject.SetActive(true);
        this.shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(true);
    }
}

