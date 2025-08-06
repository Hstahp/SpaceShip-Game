using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHole : SaiMonoBehaviour
{
    protected string sceneName = "GalaxyDemo";
    protected virtual void OnMouseDown() {
        Debug.Log("WormHole OnMouseDown");
        this.LoadGalaxy();
    }
    protected virtual void LoadGalaxy()
    {
        SceneManager.LoadScene(this.sceneName);
    }
}