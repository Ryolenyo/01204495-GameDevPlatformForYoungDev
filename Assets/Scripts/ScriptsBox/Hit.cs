using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public string target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject thisObject = gameObject.GetComponent<ScriptPlay>().thisObject;
        if (thisObject.GetComponent<HitObjectCollider>().collided == target)
        {
            gameObject.GetComponent<ScriptPlay>().outVal = true;
            thisObject.GetComponent<HitObjectCollider>().collided = "";
        }
        else
        {
            gameObject.GetComponent<ScriptPlay>().outVal = false;
        }
    }
}
