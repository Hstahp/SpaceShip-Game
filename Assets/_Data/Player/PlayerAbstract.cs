using UnityEngine;

public class PlayerAbstract : SaiMonoBehaviour
{
    [Header("Player Abstract")]
    [SerializeField] protected PlayerController playerCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }
    protected virtual void LoadPlayerController()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.GetComponent<PlayerController>();
        Debug.Log(transform.name+": LoadPlayerController", gameObject);
    }
}
