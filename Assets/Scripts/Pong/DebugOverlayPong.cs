using UnityEngine;
using System.Text;

public class DebugOverlayPong : MonoBehaviour
{
    [Header("Ball")]
    public Transform ball;

    [Header("Performance")]
    public bool showFPS = true;

    [Header("Session")]
    public float sessionStartTime;

    private bool showMenu = true;
    private float deltaTime;

   //private CoyoteTime coyoteTime;

    private void Awake()
    {
        //coyoteTime = FindAnyObjectByType<CoyoteTime>();
    }

    private void Start()
    {
        sessionStartTime = Time.time;
    }

    private void OnEnable()
    {
        //coyoteTime.onBallFellOnFloor.AddListener(HandleFall);
    }

    private void OnDisable()
    {
        //coyoteTime.onBallFellOnFloor.RemoveListener(HandleFall);
    }

    private void Update()
    {
        // Toggle debug menu with F1
        if (Input.GetKeyDown(KeyCode.F1)) showMenu = !showMenu;
        
        // FPS smoothing
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        if (!showMenu) return;

        GUI.Box(new Rect(10, 10, 320, 260), "Debug Overlay");

        var sb = new StringBuilder();

        // --- Player Telemetry ---
        sb.AppendLine("=== PLAYER ===");

        if (ball != null)
        {
            sb.AppendLine($"Position: {ball.position}");
            
            // TODO: The GetComponent is expensive, we need to cache it.
            sb.AppendLine($"Speed: {ball.GetComponent<Rigidbody>()?.linearVelocity.magnitude:F2}");
        }

        // --- Session Telemetry ---
        sb.AppendLine("\n=== SESSION ===");

        var sessionDuration = Time.time - sessionStartTime;

        sb.AppendLine($"Session Time: {sessionDuration:F1}s");
        sb.AppendLine($"Current Scene: {UnityEngine.SceneManagement.SceneManager.GetActiveScene().name}");

        // --- Performance Telemetry ---
        sb.AppendLine("\n=== PERFORMANCE ===");

        if (showFPS)
        {
            var fps = 1.0f / deltaTime;
            sb.AppendLine($"FPS: {fps:F1}");
        }

        sb.AppendLine($"Frame Time: {(deltaTime * 1000f):F2} ms");
        sb.AppendLine($"Memory Usage: {(System.GC.GetTotalMemory(false) / 1024 / 1024)} MB");

        GUI.Label(new Rect(20, 40, 300, 220), sb.ToString());
    }
}