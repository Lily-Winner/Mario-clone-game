using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D myBody;
    private Vector3 moveDerection = Vector3.down;
    private string coroutineName = "ChangeMovement";

    private void Awake()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(coroutineName);
    }

    void Update()
    {
        MoveSpider();
    }
    void MoveSpider()
    {
        transform.Translate(moveDerection * Time.smoothDeltaTime);
    }

    IEnumerator ChangeMovement()
    {
        yield return new WaitForSeconds(Random.Range(2f,5f));

        if(moveDerection == Vector3.down)
            moveDerection = Vector3.up;
        else
            moveDerection = Vector3.down;

        StartCoroutine(coroutineName);
    }

    IEnumerator SpiderDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == MyTags.BULLET_TAG)
        {
            anim.Play("SpiderDead");
            myBody.bodyType = RigidbodyType2D.Dynamic;

            StartCoroutine(SpiderDead());
            StopCoroutine(coroutineName);
        }
    }
}
