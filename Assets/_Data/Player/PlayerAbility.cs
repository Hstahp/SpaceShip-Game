using UnityEngine;

public class PlayerAbility : SaiMonoBehaviour
{
   public virtual void Acitve(AbilitiesCode abilitiesCode)
    {
        Debug.Log("abilities: " + abilitiesCode.ToString());
    }
}
