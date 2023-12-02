using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : MonoBehaviour
{
    public Transform buttomCollision;
    private Animator anim;
    public LayerMask playerLayer;
    private Vector3 moveDerection = Vector3.up;
    private Vector3 originPosition;
    private Vector3 animPosition;
    private bool startAnim;
    private bool canAnimate = true;
    
    
   
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        originPosition = transform.position;
        animPosition = transform.position;
        animPosition.y += 0.15f;
        
    }

    void Update()
    {
        CheckForCollision();
        AnimateUpDown();
    }

    void CheckForCollision()
    {
        if (canAnimate)
        {
            RaycastHit2D hit = Physics2D.Raycast(buttomCollision.position, Vector2.down, 0.1f, playerLayer);
            if (hit)
            {
                if (hit.collider.gameObject.tag == MyTags.PLAYER_TAG)
                {
                    //increase score
                    anim.Play("BlockIdle");
                    startAnim = true;
                    canAnimate = false;
                    GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG).GetComponent<ScoreScript>().AddCoins();

                }
            }
        }
    }

    void AnimateUpDown()
    {
        if (startAnim)
        {
            transform.Translate(moveDerection * Time.smoothDeltaTime);
            if(transform.position.y >= animPosition.y)
            {
                moveDerection = Vector3.down;
            }
            else if (transform.position.y <= originPosition.y)
            {
                startAnim = false;
            }
        }
    }
}
