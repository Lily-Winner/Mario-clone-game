using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == MyTags.PLAYER_TAG)
        {
            //Damage the player

        }
        gameObject.SetActive(false);
    }
}
