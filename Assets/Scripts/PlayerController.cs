using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement variables
    public int maxSpeed = 5;
    Rigidbody2D rb2d;
    Animator anim;

    // jumping variables
    bool grounded = false;
    float groundRadius = 0.2f;
    int jumpCount = 0;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight = 150f;

    // checks if char is facing right
    bool facingRight;

    // for shooting
    public Transform firePoint;
    public GameObject snowball;
    public float fireRate = 0.5f;
    float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // returns reference to the rigidbody2D component and stores it in rb2d
        // does the same for the animator component
        // this is a shortcut to avoid having to type GetComponent<>() every time
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    void Update () {
        // sets the grounded parameter in the animator to grounded
        anim.SetBool("isGrounded", grounded);
        // sets the vertical speed parameter in the animator to the vertical speed of the player
        anim.SetFloat("verticalSpeed", rb2d.velocity.y);
        // if the player is on the ground and the jump button is pressed
        if (grounded && Input.GetAxis("Jump") > 0) {
            // set the grounded parameter to false
            // hasJumped = 0f;
            grounded = false;
            anim.SetBool("isGrounded", grounded);
            jumpCount = 0;
            Debug.Log(Input.GetAxis("Jump"));
            // add a vertical force to the player
            rb2d.AddForce(new Vector2(0, jumpHeight));
        }

        // Player shooting
        if (Input.GetAxisRaw("Fire1") > 0) {
            throwSnowball();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // draws circle and checks if the player is on the ground. If it is, grounded is set to true and the player can jump
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        anim.SetBool("isGrounded", grounded);
        anim.SetFloat("verticalSpeed", rb2d.velocity.y);

        // get the horizontal input
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));
        // move the player
        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
        // Make character face the right direction
        if (move > 0 && facingRight)
        {
            Flip();
        }
        else if (move < 0 && !facingRight)
        {
            Flip();
        }
    }
    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void throwSnowball() {
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            if (facingRight) {
                Instantiate(snowball, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            } else {
                Instantiate(snowball, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 10f)));
            }
        }
    }
}
