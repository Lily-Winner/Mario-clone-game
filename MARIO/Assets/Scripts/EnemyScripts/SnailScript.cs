using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : MonoBehaviour
{

    public float moveSpeed = 1f;
    private Rigidbody2D myBody;
    private Animator enemyAnim;
    private bool moveLeft;

    public Transform left_Collision, right_Collision, top_Collision,down_Collision;
    private Vector3 left_Collision_Pos, right_Collision_Pos;
    public LayerMask playerLayer;

    private bool canMove;
    private bool stunned;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();

        left_Collision_Pos = left_Collision.position;
        right_Collision_Pos = right_Collision.position;
    }
    void Start()
    {
        moveLeft = true;
        canMove = true;
    }

    void Update()
    {
        if (canMove)
            if (moveLeft)
                myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
            else
                myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);

        CheckCollision();
    }

    void CheckCollision()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(left_Collision.position, Vector2.left,0.1f, playerLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(right_Collision.position, Vector2.right, 0.1f, playerLayer);
        Collider2D topHit = Physics2D.OverlapCircle(top_Collision.position, 0.2f, playerLayer);

        if (topHit != null && topHit.gameObject.tag == MyTags.PLAYER_TAG && !stunned)
            //if (topHit.gameObject.tag =="Player")
                //if (!stunned)
                {
                    topHit.gameObject.GetComponent<Rigidbody2D>().velocity =
                        new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 7f);

                    canMove = false;
                    myBody.velocity = new Vector2(0, 0);

                    enemyAnim.Play("Stunned");
                    stunned = true;

            if (tag == MyTags.BEETLE_TAG)
            {
                enemyAnim.Play("Stunned");
                StartCoroutine(Dead(0.5f));
            }
                
                        
                }
        if (leftHit && leftHit.collider.gameObject.tag == MyTags.PLAYER_TAG)
            if (!stunned)
            {
                //Apply Dammage to plaer
            }
            else
                if (tag != MyTags.BEETLE_TAG)
            {
                myBody.velocity = new Vector2(15f, myBody.velocity.y);
                StartCoroutine(Dead(3f));
            }
                    
                    


        if (rightHit && rightHit.collider.gameObject.tag == MyTags.PLAYER_TAG)
            if(!stunned)
            {
            //Apply Dammage to plaer
            }
            else
                if(tag != MyTags.BEETLE_TAG)
            {
                myBody.velocity = new Vector2(-15f, myBody.velocity.y);
                StartCoroutine(Dead(3f));
            }
                   



        if (!Physics2D.Raycast(down_Collision.position, Vector2.down, 0.1f))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        moveLeft = !moveLeft;
        Vector3 temporaryScale = transform.localScale;

        if (moveLeft)
        {
            temporaryScale.x = Mathf.Abs(temporaryScale.x);
            left_Collision.position = left_Collision_Pos;
            right_Collision.position = right_Collision_Pos;
        }
        else
        {
            temporaryScale.x = -Mathf.Abs(temporaryScale.x);
            right_Collision.position = left_Collision_Pos;
            left_Collision.position = right_Collision_Pos;
        }
        transform.localScale = temporaryScale;
    }
    IEnumerator Dead(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
    
}
