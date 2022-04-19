using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public ParticleSystem dust;

    //Variable for speed that player is going to move at.
    //Change to private after last number has been decided.
    public float speed;
    public float jump;
    public float jumpExtended = 0.1f;
    float jumpTimer = 0;
    private bool isJumping;

    bool isGrounded = false; 
    public Transform isGroundedChecker; 
    public LayerMask groundLayer;
    public float fallMultiplier; 
    public float lowJumpMultiplier;
    public Animator animator;
    float moveBy = 0f;

    public Joystick joystick;
    public Button JumpButton;
    public bool dojump = false;
    private BoxCollider2D boxCollider2d;

    private bool FacingRight = true;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Button btn = JumpButton.GetComponent<Button>();
        btn.onClick.AddListener(buttonJump);
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        Move();
        Jump();
        Fall();
        BetterJump();
    }

    void Move()
    {
        if (joystick.Horizontal >= .2f)
        {
            moveBy = speed;
            SoundManagerScript.PlaySound("run");
        } else if (joystick.Horizontal <= -.2f)
        {
            moveBy = -speed;
            SoundManagerScript.PlaySound("run");
        } else
        {
            moveBy = 0;
        }
        //float moveBy = - or + speed; 
    
        rb.velocity = new Vector2(moveBy, rb.velocity.y); 

        // If the input is moving the player right and the player is facing left -> flip the player
	    if (moveBy > 0 && !FacingRight)
	    {
		    // Switch the way the player is labelled as facing.
		    FacingRight = !FacingRight;

		    // Multiply the player's x local scale by -1.
		    Vector3 theScale = transform.localScale;
		    theScale.x *= -1;
		    transform.localScale = theScale;
        }
	    else if (moveBy < 0 && FacingRight)
	    {
		    FacingRight = !FacingRight;

		    Vector3 theScale = transform.localScale;
		    theScale.x *= -1;
		    transform.localScale = theScale;
	    }
        animator.SetFloat("speed", Mathf.Abs(moveBy));
    }
    //Fall animation condition
    void Fall()
    {
        if (rb.velocity.y < -0.01 && !isGrounded) {
            animator.SetBool("isFalling", true);
        }
        else {
            animator.SetBool("isFalling", false);
        }
    }

    public void buttonJump()
    {
        dojump = true;
    }
    
    // Jump animation condition
    void Jump()
    {

        if (isGrounded)
        {
            jumpTimer = jumpExtended;
        }

        if (jumpTimer > 0)
        {
            jumpTimer -= Time.deltaTime;
            if (dojump && !isJumping)
            {
                SoundManagerScript.PlaySound("jump");
                rb.velocity = new Vector2(rb.velocity.x, jump);
                isJumping = true;
                Invoke("resetIsJumping", 0.5f);
                CreateDust();
            }
        }

        if (rb.velocity.y > 0.01 && !isGrounded)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
        dojump = false;
    }

    void BetterJump() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }  
    }

    private void resetIsJumping()
    {
        isJumping = false;
    }

    //Checks if player is touching ground
    void CheckIfGrounded() {
        float extraHeight = 0.5f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeight, groundLayer);
        if (raycastHit.collider != null) { 
            isGrounded = true;
        } else { 
            isGrounded = false;
        }
    }

    void CreateDust()
    {
        dust.Play();
    }
}
