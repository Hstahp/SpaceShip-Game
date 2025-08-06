using UnityEngine;

public class SpawnerController : SaiMonoBehaviour
{
    [SerializeField] protected  Spawner spawner;
    public Spawner Spawner  => spawner; 

    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints  => spawnPoints;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadSpawnPoints();
    }
    protected virtual void LoadSpawner()
    {

        if (this.spawner != null) return;
        this.spawner = GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }
    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        //bị deprecated 
        // this.spawnPoints = Transform.FindObjectOfType<JunkSpawnPoints>();
        //this.spawnPoints = FindFirstObjectByType<SpawnPoints>(); // hoặc FindAnyObjectByType<JunkSpawnPoints>()
        this.spawnPoints = GameObject.Find("SceneSpawnPoints").GetComponent<SpawnPoints>(); 
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
