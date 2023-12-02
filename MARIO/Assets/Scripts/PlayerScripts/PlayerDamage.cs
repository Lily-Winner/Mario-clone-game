using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    private TextMeshProUGUI LifeTxt;
    private int lifeScoeCount;
    private bool canDamage;

    void Awake()
    {
        LifeTxt = GameObject.Find("Life Txt").GetComponent<TextMeshProUGUI>();
        lifeScoeCount = 3;
        LifeTxt.text = "x " + lifeScoeCount;
        canDamage = true;
    }
    private void Start()
    {
        Time.timeScale = 1f;
    }


    public void DealDamage()
    {
        if (canDamage)
        {
            lifeScoeCount--;
            if (lifeScoeCount >= 0)
                LifeTxt.text = "x " + lifeScoeCount;
            if (lifeScoeCount == 0)
            {
                //RESTART THE GAME
                Time.timeScale = 0f;
                StartCoroutine(RestartGame());
            }
            canDamage = false;
            StartCoroutine(WeitForDamage());
        }
    }
    IEnumerator WeitForDamage()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("SampleScene");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Water")
        {

            Invoke("FellDown", 1f);
        }
    }

    private void FellDown()
    {
        Time.timeScale = 0f;
        StartCoroutine(RestartGame());
    }

}
