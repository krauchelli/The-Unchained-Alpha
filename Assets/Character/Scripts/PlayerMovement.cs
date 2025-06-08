using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] public int playerNumber = 1; // 1 for Player 1, 2 for Player 2
    
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = false;
    float jumpPower = 20f;
    bool isGrounded = false;

    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input based on player number
        horizontalInput = GetHorizontalInput();

        FlipSprite();

        if (GetJumpInput() && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
            animator.SetBool("isFalling", !isGrounded && rb.linearVelocity.y < 0);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    float GetHorizontalInput()
    {
        if (playerNumber == 1)
        {
            // Player 1: WASD
            if (Input.GetKey(KeyCode.A)) return -1f;
            if (Input.GetKey(KeyCode.D)) return 1f;
            return 0f;
        }
        else if (playerNumber == 2)
        {
            // Player 2: Arrow Keys
            if (Input.GetKey(KeyCode.LeftArrow)) return -1f;
            if (Input.GetKey(KeyCode.RightArrow)) return 1f;
            return 0f;
        }
        return 0f;
    }

    bool GetJumpInput()
    {
        if (playerNumber == 1)
        {
            // Player 1: W key
            return Input.GetKeyDown(KeyCode.W);
        }
        else if (playerNumber == 2)
        {
            // Player 2: Up Arrow
            return Input.GetKeyDown(KeyCode.UpArrow);
        }
        return false;
    }

    void FlipSprite()
    {
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }
}