using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    private Animator anim;

    public GameObject collected;
    public int Score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Check when the character touches the object/apple
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Trigger when the apple collide the tag "Player"
        if(collider.gameObject.tag == "Player")
        {  
            // Disable both components, the collider and the sprite renderer
            sr.enabled = false;
            circle.enabled = false;

            // Activates the collected object effect
            collected.SetActive(true);
            anim.SetTrigger("collected");

            // Giving access to game controller
            GameController.instance.totalScore += Score;

            // Calling the score to update it
            GameController.instance.UpdateScoreText();

            // Destroy the object after 1 second to allow the effect
            Destroy(gameObject, 0.25f);
        }
    }
}
