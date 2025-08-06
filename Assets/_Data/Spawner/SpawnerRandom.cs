using UnityEngine;

public class SpawnerRandom : SaiMonoBehaviour
{
    [Header("Spawner Random")]
    [SerializeField] protected SpawnerController spawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (this.spawnerCtrl != null) return;
        this.spawnerCtrl = GetComponent<SpawnerController>();
        Debug.Log(transform.name + ": LoadJunkController", gameObject);
    }

    protected override void Start()
    {
       // this.JunkSpawning();
    }
    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;
        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0f;  

        Transform ranPoint = this.spawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.spawnerCtrl.Spawner.RandomPrefab();
        Transform obj= this.spawnerCtrl.Spawner.Spawn(prefab, pos, rot); 
        obj.gameObject.SetActive(true);
        //đệ quy
        //Invoke(nameof(this.JunkSpawning), 1f);
    }
    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.spawnerCtrl.Spawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
