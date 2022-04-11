using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] public LayerMask platformLayerMask;

    public float maxHealth;
    public float maxHealth2;
    public int enemyDamage;
    
    public GameObject player;
    public Rigidbody2D rb;
    public BoxCollider2D bd2D;

    public float speed;
    public float jumpForce;
    public float smallJump;
    
    public bool facingRight;

    public float wallSlideSpeed;
    public bool isSliding;
    public Transform front;
    public bool touchWall;
    public bool touchFloor;
    public Transform ground;

    public bool wallJumping;
    public bool wallJumping2;

    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    public Animator anim;

    public GameObject health1;
    public GameObject health2;

    float jumpRemembertime = 0.2f;
    float jumpRemember = 0f;

    int jumpCount = 2;

    public AudioSource jumpSound;
    public AudioSource wallJumpSound;
    public AudioSource damaged;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bd2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Move();
        Jump();
        WallJump();
        Death();
        Animations();
    }


    void Death()
    {
        if(maxHealth == maxHealth2)
        {
            health1.SetActive(true);
            health2.SetActive(true);
        }
        else if (maxHealth == 1)
        {
            health1.SetActive(true);
            health2.SetActive(false);
        }


        if (maxHealth <= 0)
        {
            player.transform.position = CheckPointScript.GetActiveCheckPointPosition();
            maxHealth = maxHealth2;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (col.gameObject.tag == "Enemy")
        {
            maxHealth -= enemyDamage;
            damaged.Play(0);
        }
        if (col.gameObject.tag == "DeathZone")
        {
            maxHealth -= 10;
        }
        if(col.gameObject.tag == "CheckPoint" && maxHealth < 2)
        {
            maxHealth = maxHealth2;
        }
    }

    public void Move()
    {
       float move = Input.GetAxisRaw("Horizontal");
       rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (move < 0 && facingRight == false) 
        {
            Flip();
        }
        else if (move > 0 && facingRight == true)
        {
            Flip();
        }
    }
    bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(bd2D.bounds.center, bd2D.bounds.size, 0, Vector2.down, 0.1f, platformLayerMask);
        return raycastHit2D.collider != null;
    }
    void Jump()
    {
        jumpRemember -= Time.deltaTime;

        if (Input.GetButtonDown("Jump")) 
        {
            jumpRemember = jumpRemembertime;
        }

        if (Input.GetButtonUp("Jump"))
        {
            if(rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * smallJump);

            }
        }

        if (isGrounded() && jumpRemember > 0 )
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpSound.Play(0);

        }

        if (isGrounded())
        {
            jumpCount = 2;
        }
        else if (!isGrounded() && jumpCount == 2)
        {
            jumpCount = 1;
        }
        else if (jumpCount == 1 && Input.GetButtonDown("Jump") && touchWall == false)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpCount = 0;
            jumpSound.Play(0);
        }
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }

    void WallJump()
    {
        float move = Input.GetAxisRaw("Horizontal");

        touchWall = Physics2D.OverlapCircle(front.position, 0.2f, platformLayerMask);


        if (touchWall == true && isGrounded() == false && move != 0)
        {
            isSliding = true;
        }
        
        else
        {
            isSliding = false;
        }

        if (isSliding == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }


        if(isSliding == true && Input.GetButtonDown("Jump") && facingRight == false)
        {
            wallJumping = true;
            Invoke("SetWallFalse", wallJumpTime);
            jumpCount = 1;
        }
        if (isSliding == true && Input.GetButtonDown("Jump") && facingRight == true)
        {
            wallJumping2 = true;
            Invoke("SetWallFalse2", wallJumpTime);
            jumpCount = 1;
        }
        if (wallJumping == true)
        {
            rb.velocity = new Vector2(xWallForce * -move, yWallForce);
            wallJumpSound.Play(0);
        }
        else if (wallJumping2 == true)
        {
            rb.velocity = new Vector2(xWallForce * -move, yWallForce);
            wallJumpSound.Play(0);
        }
    }

    void SetWallFalse()
    {
        wallJumping = false;
    }
    void SetWallFalse2()
    {
        wallJumping2 = false;
    }
    void Animations()
    {
        float animMove = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(animMove));
        touchFloor = Physics2D.OverlapCircle(ground.position, 0.2f, platformLayerMask);

        if (touchFloor == false)
        {
            anim.SetBool("inAir", true);
        }
        else if(touchFloor == true)
        {
            anim.SetBool("inAir", false);
        }
        if(rb.velocity.y > 1.2)
        {
            anim.SetFloat("airSpeed", 2);
        }
        else if (rb.velocity.y < -1.2f)
        {
            anim.SetFloat("airSpeed", -2);
        }
        else
        {
            anim.SetFloat("airSpeed", 0);
        }

        if(isSliding == true)
        {
            anim.SetBool("onWall", true);
        }
        else
        {
            anim.SetBool("onWall", false);
        }
    }
}
