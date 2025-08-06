using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCam;
    protected override void LoadComponents()
    {
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        //line code was old 
        //  this.mainCam = Transform.FindObjectOfType<Camera>().transform;
        //repair to 2 line code bottom
        Camera cam = FindFirstObjectByType<Camera>();
        if (cam != null) this.mainCam = cam.transform;

        Debug.Log(transform.parent.name + ": LoadCamera", gameObject);
    }
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position,this.mainCam.position);
        if (this.distance > this.disLimit) return true;
        return false;
    }
}
