using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float resetsped = 0.5f;
    public float cameraSpeed = 0.3f;

    public Bounds cameraBounds;
    private Transform target; //Player
    private float offsetZ;    //offset player pos from camera pos
    private Vector3 lastTargetPosition;
    private Vector3 currentVelocity;
    private bool followsPlayer;

    private void Awake()
    {
        BoxCollider2D myCol = GetComponent<BoxCollider2D>();
        myCol.size = new Vector2 (Camera.main.aspect*2f*Camera.main.orthographicSize, 15f);
        cameraBounds = myCol.bounds; //bounds of camera now its a bouns of boxcollider of camera
        print(myCol.size);
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG).transform;
        lastTargetPosition = target.position;
        offsetZ = (transform.position - target.position).z;
        followsPlayer = true;
        
    }

    void FixedUpdate()
    {
        if (followsPlayer)
        {
            Vector3 aheadTargetPos = target.position + Vector3.forward * offsetZ;
            Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position,
                    aheadTargetPos, ref currentVelocity, cameraSpeed);
            transform.position = new Vector3(newCameraPosition.x,
                transform.position.y, newCameraPosition.z);
            lastTargetPosition = target.position;


            //if (aheadTargetPos.x >= transform.position.x)
            //{
            //    Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position,
            //        aheadTargetPos, ref currentVelocity, cameraSpeed);
            //    transform.position = new Vector3(newCameraPosition.x,
            //        transform.position.y, newCameraPosition.z);
            //    lastTargetPosition = target.position;
            //}
            //else
            //{
            //    Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position,
            //        aheadTargetPos, ref currentVelocity, cameraSpeed);
            //    transform.position = new Vector3(newCameraPosition.x,
            //        transform.position.y, newCameraPosition.z);
            //    lastTargetPosition = target.position;
            //}
            //if (aheadTargetPos.x == 85.8f)
            //{
            //    Vector3 temporary = transform.position;
            //    temporary.x = 85.8f;
            //    transform.position = temporary;
            //}
        }
       
        
    }
}
