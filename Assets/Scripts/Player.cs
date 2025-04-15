using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;

    // Fixing the fan bug
    bool isBlowing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        
        // anim.SetBool("walk", true); --> this try got me a bug

        // Walking right
        if (Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
            // Character is "looking" right when walking
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        // Walking left
        if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            // Character is "looking" right when walking
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        // No walking
        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isBlowing)
        {
            // Animation when the character is moving
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    // Check if the character is touching the floor
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            // Stops the jumping animation
            anim.SetBool("jump", false);
        }

        // Calling the game over method
        if(collision.gameObject.tag == "Spike")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject); // Destroy the character
        }
    }

    //Check when the character is not touching the floor
    private void OnCollision2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

    // Fixing bug with the player hitting the fan due to the extra gravity force
    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 11)
        {
            isBlowing = true;
        }
    }

    // Get the isBlowing back to false
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {
            isBlowing = false;
        }
    }
}
