using UnityEngine;

public class ObjMoveForward : ObjMovement
{
    [SerializeField] protected Transform moveTarget;
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
    }
    protected virtual void LoadTarget()
    {
        if (this.moveTarget != null) return;
        this.moveTarget = transform.Find("MoveTarget");
        Debug.Log(transform.name + ":LoadTarget", gameObject);
    }
    protected virtual void GetMousePosition()
    {
        this.targetPosition = moveTarget.position;
        this.targetPosition.z = 0;
    }
}
