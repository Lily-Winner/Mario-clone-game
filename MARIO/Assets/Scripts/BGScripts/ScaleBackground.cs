using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour
{

    void Start()
    {
        // Take a size of sprite

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(1,1,1);
        float width = sr.sprite.bounds.size.x;  // =32
        float height = sr.sprite.bounds.size.y; // =18.7
        
        //Set the world H/W == camera/screen size

        float worldHeight = Camera.main.orthographicSize * 2f; // =10
        float worldWidth = (worldHeight / Screen.height) * Screen.width; // = 17 //same that Camera.main.aspect
        
        // camera scale divide by sprite scale - get a new scale of sprite

        Vector3 tempScale = transform.localScale;   //curent scale of background
        tempScale.x = worldWidth / width + 0.1f;    // 17/32
        tempScale.y = worldHeight / height + 0.1f;  // 10/18.7
        transform.localScale = tempScale;           // 0.66, 0.63, 1
        
    }
}
    
