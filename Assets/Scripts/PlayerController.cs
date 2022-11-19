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
    public LayerMask groundLayer;
    public Transform groundCheck;
    public int maxJumps;
    public int jumpCount;
    public float jumpHeight = 500f;

    // checks if char is facing right
    bool facingRight;

    // for shooting
    public Transform firePoint;
    public GameObject snowball;
    public GameObject sandball;
    public GameObject grassball;
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
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))) {
            if (jumpCount > 0) {
                rb2d.AddForce(new Vector2 (0, jumpHeight), ForceMode2D.Impulse);
                grounded = false;
                jumpCount -= 1;
            } else {
                // do nothing

                // return;
            }
            // set the grounded parameter to false
            // hasJumped = 0f;
            // grounded = false;
            // anim.SetBool("isGrounded", grounded);
            // jumpCount = 0;
            // add a vertical force to the player
            // rb2d.AddForce(new Vector2(0, jumpHeight));
            // run jump function
            // jump();
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
        if (grounded) {
            jumpCount = maxJumps;
        }
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
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            jumpCount = maxJumps;
            grounded = true;
        }
    }
    void throwSnowball() {
        if (sandball && !grassball) {
        // generate random number between 1 and 10
        int rand = Random.Range(1, 10);
        // if number is <=5 throw snowball
            if (rand <= 5) {
                if (Time.time > nextFire) {
                    nextFire = Time.time + fireRate;
                    if (facingRight) {
                        Instantiate(sandball, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    } else {
                        Instantiate(sandball, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 10f)));
                    }
                }
            } else {
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
        if (grassball && sandball) {
        // generate random number between 1 and 10
        int rand = Random.Range(1, 10);
        // if number is <=5 throw snowball
            if (rand <= 2) {
                if (Time.time > nextFire) {
                    nextFire = Time.time + fireRate;
                    if (facingRight) {
                        Instantiate(sandball, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    } else {
                        Instantiate(sandball, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 10f)));
                    }
                }
            } 
            if (rand >2 && rand <= 5) {
                if (Time.time > nextFire) {
                    nextFire = Time.time + fireRate;
                    if (facingRight) {
                        Instantiate(snowball, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    } else {
                        Instantiate(snowball, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 10f)));
                    }
                }
            } else {
                if (Time.time > nextFire) {
                    nextFire = Time.time + fireRate;
                    if (facingRight) {
                        Instantiate(grassball , firePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    } else {
                        Instantiate(grassball, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 10f)));
                    }
                }
            }
        } else {
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
}
