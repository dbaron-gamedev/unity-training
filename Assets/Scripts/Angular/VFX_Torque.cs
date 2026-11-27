using UnityEngine;

public class VFX_Torque : MonoBehaviour
{
    private ParticleSystem particles;
    public Torque torque;
    
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        print(torque._material.color);
    }

    void Update()
    {
        var e = particles.emission;
        e.rateOverTime = torque.angularVelocity;
        var c = particles.main;
        c.startColor = torque._material.color;
    }
}
