using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private float speed = 10f;
    private Animator bulletAnimation;

    

    private bool canMove;

    private void Awake()
    {
        bulletAnimation = GetComponent<Animator>();

    }

    void Start()
    {
        canMove = true;
        StartCoroutine (DisableBullet(5f));
    }

    
    void Update()
    {
        Move();
    }


    void Move()
    {
        if (canMove)
        {
            Vector3 temporary = transform.position;
            temporary.x += speed * Time.deltaTime;
            transform.position = temporary;
        }

    }
    public float Speed {
        get {
            return speed;
        }
        set {
            speed = value;
        }
    }
    IEnumerator DisableBullet(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == MyTags.BEETLE_TAG || other.gameObject.tag == MyTags.SNAIL_TAG)
        {
            bulletAnimation.Play("Explode");
            canMove = false;
            StartCoroutine(DisableBullet(0.1f));
        }

    }
}
