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

    bool isFalling = false;
    bool isJumping = false;
    bool isGrounded = false; 
    public Transform isGroundedChecker; 
    public float checkGroundRadius; 
    public LayerMask groundLayer;
    public float fallMultiplier; 
    public float lowJumpMultiplier;
    public Animator animator;

    public Joystick joystick;
    public Button JumpButton;
    public bool dojump = false;

    private bool FacingRight = true;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        Button btn = JumpButton.GetComponent<Button>();
        btn.onClick.AddListener(buttonJump);
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

    float x = joystick.Horizontal; 
    float moveBy = x * speed; 
    animator.SetFloat("speed", Mathf.Abs(moveBy));
    
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
    

    }
    //Fall animation condition
    void Fall()
    {
        if (rb.velocity.y < -0.01) {
            animator.SetBool("isFalling", true);
        }
        else {
            animator.SetBool("isFalling", false);
        }
    }

    void buttonJump()
    {
        dojump = true;
    }
    // Jump animation condition
    void Jump()
    {


        if(dojump && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            CreateDust();
            
        }
        if (rb.velocity.y > 0.01) {
            animator.SetBool("isJumping", true);
        }
        else {
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
    //Checks if player is touching ground
    void CheckIfGrounded() { 
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer); 
        if (collider != null) { 
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
