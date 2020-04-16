using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolean : MonoBehaviour
{
    public bool outValue;
    public bool fromPass;
    
    // Start is called before the first frame update
    void Start()
    {
        outValue = false;
        fromPass = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<ScriptPlay>().outVal = fromPass;
    }
}
