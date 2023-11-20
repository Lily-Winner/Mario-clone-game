using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D myBody;
    private Animator playerAnim;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        PlayerWalk();
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
}
