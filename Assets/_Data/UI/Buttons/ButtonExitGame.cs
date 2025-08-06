using UnityEditor;
using UnityEngine;

public class ButtonExitGame : BaseButton
{
    protected override void OnClick()
    {
        Debug.Log("On click ButtonExitGame");
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #endif
        Application.Quit();
    }
}
