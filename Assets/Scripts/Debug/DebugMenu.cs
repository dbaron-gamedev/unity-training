using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenu : MonoBehaviour
{
    [Header("Menu Settings")]
    public bool showMenu = true;
    public KeyCode toggleKey = KeyCode.F2;
    
    private Vector2 scrollPosition;

    public GameObject ball_prefab;

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

        GUILayout.Label("Actions:");

        if (GUILayout.Button("Del Ball", GUILayout.Height(30)))
            DelBall();
        if (GUILayout.Button("Spawn Ball", GUILayout.Height(30)))
            SpawnBall();

        GUILayout.EndScrollView();
        GUILayout.Space(10);
        GUILayout.Label("Press F1 to toggle menu");
        GUILayout.EndArea();
    }


    private void DelBall()
    {
        Debug.Log("Del");
        GameObject ball = GameObject.Find("Ball");

        if (ball != null)
        {
            Destroy(ball);
        }
    }

    private void SpawnBall()
    {
        GameObject ball = GameObject.Find("Ball");

        if (ball == null)
        {
            Debug.Log("Spawn");
            GameObject new_ball = Instantiate(ball_prefab, Vector3.zero, Quaternion.identity);
            new_ball.name = "Ball";
        }

        else
        {
            Debug.Log("Can't Spawn, already exists");
        }
    }
}