using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

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
}
