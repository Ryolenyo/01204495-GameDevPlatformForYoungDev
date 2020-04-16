using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
    public string button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(button))
        {
            gameObject.GetComponent<ScriptPlay>().outVal = true;
        }
        else
        {
            gameObject.GetComponent<ScriptPlay>().outVal = false;
        }
    }
}
