using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System.Collections.Generic;

public class BuildScript
{
    [System.Obsolete]
    public static void Build(int Clients, string[] Scenes)
    {
        if(SystemInfo.operatingSystem.Contains("Mac OS")){
            PlayerSettings.displayResolutionDialog = (UnityEditor.ResolutionDialogSetting) 1;
            BuildPlayer();
            PlayerSettings.displayResolutionDialog = (UnityEditor.ResolutionDialogSetting) 0;
            for (int i = 0; i < Clients; i++)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "open";
                startInfo.Arguments = "./builds/game/plataformer.app -n";
                startInfo.UseShellExecute = true;
                Process.Start(startInfo);
            }
        }
    }

    private static void BuildPlayer()
    {
        // Build the player
        List<string> defaultScenes = new List<string>();
        foreach (EditorBuildSettingsScene scene
            in EditorBuildSettings.scenes)
        {
            defaultScenes.Add(scene.path);
        }
        BuildPipeline.BuildPlayer(defaultScenes.ToArray(), "./builds/game/plataformer.app", BuildTarget.StandaloneOSX, BuildOptions.None);
    }
}
