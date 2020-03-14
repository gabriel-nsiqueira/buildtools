using UnityEditor;
using UnityEngine;

public class BuildWindow : EditorWindow
{
    int clients = 1;
    
    [MenuItem("Tools/Build")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<BuildWindow>("Build Tools");
    }
    private void OnGUI()
    {
        clients = EditorGUILayout.IntField("Clients amount", clients, options: null);
        
        GUILayout.BeginArea(new Rect(0, 60, 700, 1000));
        GUILayout.Label("Scenes:");
        foreach (EditorBuildSettingsScene scene
            in EditorBuildSettings.scenes)
        {
            string[] ara = scene.path.Split('/');
            GUILayout.Label("       " + ara[ara.Length - 1].Split('.')[0]);
        }
        GUILayout.EndArea();
        if (GUILayout.Button("Build and open"))
        {
            BuildScript.Build(clients, Application.GetBuildTags());
        }
    }
}
