using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private TextMeshProUGUI coinTextScore;
    private AudioSource audioManager;
    private int scoreCount;
    
    

    private void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }

    void Start()
    {
        coinTextScore = GameObject.Find("Coins Txt").GetComponent<TextMeshProUGUI>();
    }
    public void AddCoins()
    {
        scoreCount++;
        coinTextScore.text = "x" + scoreCount;
        audioManager.Play();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == MyTags.COIN_TAG)
        {
            AddCoins();
            target.gameObject.SetActive(false);
        }

    }
   

}