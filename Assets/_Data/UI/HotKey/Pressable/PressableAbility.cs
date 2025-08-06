using UnityEngine;

public class PressableAbility : Pressable 
{
    [SerializeField] protected AbilitiesCode ability;
    public override void Pressed()
    {
        PlayerController.Instance.PlayerAbility.Acitve(ability);
    }
}
