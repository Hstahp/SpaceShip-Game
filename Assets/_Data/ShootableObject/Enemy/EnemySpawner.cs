using UnityEngine;
public class EnemySpawner : Spawner 
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null) Debug.LogError("Only 1 EnemySpawner allow to exsit");
        EnemySpawner.instance = this;   
    }
    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newEnemy = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBar2Obj(newEnemy);
        return newEnemy;
    }
    protected virtual void AddHPBar2Obj(Transform newEnemy)
    {
        ShootableObjectCtrl newEnemyCtrl = newEnemy.GetComponent<ShootableObjectCtrl>();
        Transform newHpBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);
        HPBar hPBar = newHpBar.GetComponent<HPBar>();
        hPBar.SetObjecCtrl(newEnemyCtrl);
        hPBar.SetFollowTarget(newEnemy);
        newHpBar.gameObject.SetActive(true);    
    }
}