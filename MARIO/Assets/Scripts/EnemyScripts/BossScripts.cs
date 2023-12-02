using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScripts : MonoBehaviour
{
    public GameObject stone;
    public Transform attackInstantiate;
    private Animator bossAnimation;
    


    void Awake()
    {
        bossAnimation = gameObject.GetComponent<Animator>();
        
    }


    void Start()
    {
        StartCoroutine("StartAttack");
    }

 
    void BackToIdle()
    {
        bossAnimation.Play("BossIdle");
    }
    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));

        bossAnimation.Play("BossAttack");
        StartCoroutine("StartAttack");
    }

    void Attack()
    {
        GameObject obj = Instantiate(stone, attackInstantiate.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300f, -700f), 0f));
    }

    public void DeactivateBossScript()
    {
        StopCoroutine("StartAttack");
        enabled = false;
    }
}
