using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerTests
{
    private const string SceneName = "GameScene";
    [UnityTest]
    public IEnumerator Player_IsSetUpCorrectly()
    {
        // Load the scene
        if (!SceneManager.GetSceneByName(SceneName).isLoaded)
        SceneManager.LoadScene(SceneName);

        // Waits for one frame.
        yield return null; 

        // Check if the player exists in the scene
        GameObject player = GameObject.FindWithTag("Player");
        Assert.IsNotNull(player, "Player not in the scene");  // Assert is basically a true/false check, but it will force you to provide a false statement. 

        // Check if the player has a Rigidbody2D component
        Rigidbody2D rb2D = player.GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rb2D, "Player does not have a Rigidbody2D component");

        // Check if the player has a Collider2D component
        Collider2D collider2D = player.GetComponent<Collider2D>();
        Assert.IsNotNull(collider2D, "Player does not have a Collider2D component");

        // Check Rigidbody2D properties
        Assert.AreEqual(RigidbodyType2D.Dynamic, rb2D.bodyType, "Rigidbody2D should be set to Dynamic");
        Assert.AreEqual(0.0f, rb2D.gravityScale, "Rigidbody2D gravity scale should be 0");
    }
}

// Useful for testing if the player is set up correctly in the scene, ensuring that it has the necessary components and properties for proper functionality.