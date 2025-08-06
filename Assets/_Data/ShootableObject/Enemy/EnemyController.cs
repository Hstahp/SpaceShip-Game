using UnityEngine;

public class EnemyController : AbilityObjectCtrl
{
    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString(); 
    }
}
