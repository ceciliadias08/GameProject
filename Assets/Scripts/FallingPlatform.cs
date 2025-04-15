using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime;

    private TargetJoint2D target;
    private BoxCollider2D boxColl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    // Check if the platform touched the player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Method to fall after 1 seconds(defined on unity)
            Invoke("Falling", fallingTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
       // Destry the platform when it touches the game object
        if (collider.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        target.enabled = false;
        boxColl.isTrigger = true;
    }

}
