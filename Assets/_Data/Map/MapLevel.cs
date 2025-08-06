using Unity.VisualScripting;
using UnityEngine;

public class MapLevel : LevelByDistance
{
   //[Header("Map")]
   protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.MapSetTartet();
    }
    protected virtual void MapSetTartet()
    {
        if (this.target != null) return;
        ShipController currentShip = PlayerController.Instance.CurrentShip;
        this.SetTarget(currentShip.transform);
    }
}
