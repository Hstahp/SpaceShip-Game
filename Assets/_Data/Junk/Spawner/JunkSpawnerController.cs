using UnityEngine;

public class JunkSpawnerController : SaiMonoBehaviour
{
    [SerializeField] protected  JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }

    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints { get => spawnPoints; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoints();
    }
    protected virtual void LoadJunkSpawner()
    {

        if (this.JunkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }
    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        //bị deprecated 
        // this.spawnPoints = Transform.FindObjectOfType<JunkSpawnPoints>();
        this.spawnPoints = FindFirstObjectByType<SpawnPoints>(); // hoặc FindAnyObjectByType<JunkSpawnPoints>()
        Debug.LogWarning(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
