using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public class AutomatedLightingBaker
{
    public static void LightingBaker()
    {
        Debug.Log("[CI Bake] Scanning for active scenes to bake...");

        // Example: Automatically bake all scenes in your target Scenes directory
        string[] targetScenes = Directory.GetFiles("Assets/Scenes", "*.unity", SearchOption.AllDirectories);

        foreach (string scenePath in targetScenes)
        {
            Debug.Log($"[CI Bake] Processing: {scenePath}");
            var scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

            // Clean old local lightmaps before baking a fresh set
            Lightmapping.Clear();

            // Kick off synchronous bake
            if (Lightmapping.BakeAsync())
            {
                while (Lightmapping.isRunning)
                {
                    System.Threading.Thread.Sleep(1000); // Wait for GPU/CPU engine
                }
                Debug.Log($"[CI Bake] Successfully baked: {scene.name}");
            }
            else
            {
                Debug.LogError($"[CI Bake] Failed to start bake on: {scene.name}");
                EditorApplication.Exit(1);
            }

            EditorSceneManager.SaveScene(scene);
        }

        AssetDatabase.SaveAssets();
        Debug.Log("[CI Bake] All maps completed successfully.");
        EditorApplication.Exit(0);
    }
}