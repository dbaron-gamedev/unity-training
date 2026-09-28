using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenu : MonoBehaviour
{
    [Header("Menu Settings")]
    public bool showMenu = true;
    public KeyCode toggleKey = KeyCode.F2;

    [SerializeField] private GameObject ball;
    
    private Vector2 scrollPosition;

    public Ball ballScript;

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey)) 
            showMenu = !showMenu;
    }

    private void OnGUI()
    {
        if (!showMenu) return;

        GUILayout.BeginArea(new Rect(10, 10, 300, 500), "Debug Scene Menu", GUI.skin.window);
        GUILayout.Label("Available Scenes:");

        scrollPosition = GUILayout.BeginScrollView(scrollPosition);

        var sceneCount = SceneManager.sceneCountInBuildSettings;
        for (var i = 0; i < sceneCount; i++)
        {
            var scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            var sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

            if (GUILayout.Button(sceneName, GUILayout.Height(30)))
                SceneManager.LoadScene(i);
        }

        GUILayout.Label("Ball Settings");

        if (GUILayout.Button("Destroy Ball"))
        {
            ball.SetActive(false);
        }

        if (GUILayout.Button("Respawn Ball"))
        {
            ball.SetActive(true);
            ball.transform.position = Vector3.zero;
            ballScript.Launch();
        }

        GUILayout.EndScrollView();
        GUILayout.Space(10);
        GUILayout.Label("Press F1 to toggle menu");
        GUILayout.EndArea();
    }
}