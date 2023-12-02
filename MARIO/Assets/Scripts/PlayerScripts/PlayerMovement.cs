using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D myBody;
    private Animator playerAnim;

    public Transform groundCheckPosition;
    public LayerMask groundLayer;
    private Transform myPos;

    private bool isGrounded;
    private bool jumped;
    private float jumpPower = 12f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        PlayerWalk();
        //StopMove();
    }

    private void Update()
    {
        CheckIfGrounded();
        PlayerJump();
    }

    void PlayerWalk()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
            ChangedDerection(1);
        }
        else if (h < 0)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
            ChangedDerection(-1);
        } 
        else
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        playerAnim.SetInteger("Speed", Mathf.Abs((int)myBody.velocity.x));
    }

    void ChangedDerection(int derection)
    {
        Vector3 temporaryScale = transform.localScale;
        temporaryScale.x = derection;
        transform.localScale = temporaryScale;
    }

    void PlayerJump()
    {
        if (isGrounded)
            if (Input.GetKey(KeyCode.Space))
            {
                jumped = true;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);
                playerAnim.SetBool("Jump", true);
            }
    }

    void CheckIfGrounded()
    {
        if (isGrounded = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.1f, groundLayer))
            if (isGrounded)
                if (jumped)
                {
                    jumped = false;
                    playerAnim.SetBool("Jump", false);
                }
    }

    

}
