using UnityEditor;
using UnityEngine;
using System.IO;

public class LightmapValidator
{
    private static bool ValidateBakeIntegrity(string sceneName, string scenePath)
    {
        Debug.Log($"[Validation] Verifying data integrity for {sceneName}...");

        // Test 1: Verify the physical LightingData asset exists and isn't empty
        string folderPath = Path.Combine(Path.GetDirectoryName(scenePath), sceneName);
        string lightingDataPath = $"{folderPath}_LightingData.asset";

        if (!File.Exists(lightingDataPath) || new FileInfo(lightingDataPath).Length < 2048) // Under 2KB is empty
        {
            Debug.LogError($"[Validation FAILED] {lightingDataPath} is missing or empty!");
            return false;
        }

        // Test 2: Check if Unity's active runtime settings registered the lightmaps
        LightmapData[] lightmaps = LightmapSettings.lightmaps;
        if (lightmaps == null || lightmaps.Length == 0)
        {
            Debug.LogError($"[Validation FAILED] Scene {sceneName} built, but contains 0 registered lightmaps!");
            return false;
        }

        // Test 3: Detect "Pure Black" or Broken Texture Fallbacks
        foreach (var data in lightmaps)
        {
            Texture2D colorMap = data.lightmapColor;
            if (colorMap == null)
            {
                Debug.LogError($"[Validation FAILED] Detected a broken lightmap slot reference in {sceneName}!");
                return false;
            }

            // GPU Fallback Check: Unity 6 returns a fallback texture when bakes crash silently.
            // Check if the texture is perfectly locked to absolute zero values.
            if (IsTextureCorruptedBlack(colorMap))
            {
                Debug.LogError($"[Validation FAILED] Lightmap texture {colorMap.name} is entirely black/corrupted!");
                return false;
            }
        }

        Debug.Log($"[Validation SUCCESS] {sceneName} lightmaps passed all automated health checks.");
        return true;
    }

    private static bool IsTextureCorruptedBlack(Texture2D tex)
    {
        // For large pipeline textures, reading thousands of pixels on CPU can be slow.
        // We sample a 10-point diagonal matrix across the texture to check for complete black death.
        int samples = 10;
        int blackPoints = 0;

        for (int i = 0; i < samples; i++)
        {
            int x = (tex.width / samples) * i;
            int y = (tex.height / samples) * i;
            Color pixel = tex.GetPixel(x, y);

            // In HDR lightmaps, pure black (0,0,0,1) indicates a failed photon compute pass
            if (pixel.r == 0f && pixel.g == 0f && pixel.b == 0f)
            {
                blackPoints++;
            }
        }

        // If every sampled point across the matrix is dead black, the texture is corrupt
        return blackPoints == samples;
    }
}