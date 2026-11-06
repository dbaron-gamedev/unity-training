using UnityEngine;
using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class ExplosionTest
{
    [UnityTest]
    public IEnumerator Explosion_WhenTriggered_AffectsSphere()
    {
        yield return SceneManager.LoadSceneAsync("Explosion");

        var sphere = GameObject.Find("Sphere").GetComponent<Rigidbody>();
        var explosionController = Object.FindAnyObjectByType<ExplosionController>();

        Assert.IsNotNull(explosionController);
        Assert.IsNotNull(sphere);

        sphere.useGravity = false;
        sphere.isKinematic = false;
        sphere.linearVelocity = Vector3.zero;
        sphere.angularVelocity = Vector3.zero;
        
        var initialVelocity = sphere.linearVelocity;    

        //explosionController.Explode();

        yield return new WaitForFixedUpdate();

        var velocityChange = sphere.linearVelocity - initialVelocity;

        Assert.Greater(velocityChange.magnitude, 0.01f);
    }

    [UnityTest]
    public IEnumerator Explode_WhenSphereIsNearby_ReducesHealth()
    {
        // Arrange

        // Act

        yield return null;

        // Assert
        Assert.True(true);

        // Hint
        /**
        Assert.AreEqual(
            expectedHealth,
            health.currentHealth,
            0.01f,
            "The sphere did not receive the expected explosion damage."
        );
        **/
    }
}
