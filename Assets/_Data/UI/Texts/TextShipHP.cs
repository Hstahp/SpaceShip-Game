using UnityEngine;

public class TextShipHP : BaseText
{
   protected virtual void FixedUpdate()
    {
        this.UpdateShipHP();
    }
    protected virtual void UpdateShipHP()
    {
        int hpMax = PlayerController.Instance.CurrentShip.DamageReceiver.HPMax;
        int hp = PlayerController.Instance.CurrentShip.DamageReceiver.HP;
        this.text.SetText(hp + " / " + hpMax);

    }
}
