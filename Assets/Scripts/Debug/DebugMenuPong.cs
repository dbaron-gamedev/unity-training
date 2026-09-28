using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenuPong : MonoBehaviour
{
    [Header("Menu Settings")]
    public bool showMenu = true;
    public KeyCode toggleKey = KeyCode.F2;
    
    [Header("Target")]
    private GameObject ball;
    
    private Vector2 scrollPosition;

    private void Start()
    {
        if(GameObject.Find("Ball")) ball = GameObject.Find("Ball");
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey)) 
            showMenu = !showMenu;
    }

    private void OnGUI()
    {
        if (!showMenu) return;

        GUILayout.BeginArea(new Rect(10, 10, 300, 500), "Debug Scene Menu Pong", GUI.skin.window);

        scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        if(GUILayout.Button("Destroy Ball", GUILayout.Height(30))) Destroy(ball);
        if(GUILayout.Button("Respawn Ball", GUILayout.Height(30))) Instantiate(ball,  Vector3.zero, Quaternion.identity);

        GUILayout.EndScrollView();
        GUILayout.Space(10);
        GUILayout.Label("Press F3 to toggle menu");
        GUILayout.EndArea();
    }
}