using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // Handles the animation
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Controls the jump force
    public float jumpForce;

    // Checks if the trampoline has a collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("jump");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }
}
