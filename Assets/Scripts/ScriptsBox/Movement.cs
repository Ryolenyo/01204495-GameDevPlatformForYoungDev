using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocityX;
    public float velocityY;
    public float velocityZ;

    //public bool playScript = false;

    // Start is called before the first frame update
    void Start()
    {
        velocityX = 0;
        velocityY = 0;
        velocityZ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<ScriptPlay>().play)
        {
            //Debug.Log("Running: "+velocityX +", "+velocityY+", "+velocityZ);
            GameObject thisObject = gameObject.GetComponent<ScriptPlay>().thisObject;
            thisObject.transform.position = new Vector3(thisObject.transform.position.x + velocityX, 
                thisObject.transform.position.y + velocityY, 
                thisObject.transform.position.z + velocityZ);
        }
        /*if (playScript)
        {
            transform.position = new Vector3(transform.position.x+velocityX,transform.position.y+velocityY,transform.position.z+velocityZ);
        }*/
    }
}
