using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public string target;
    public float speed;

    private bool played;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject targetOBJ = GameObject.Find(target);
        if (gameObject.GetComponent<ScriptPlay>().play)
        {
            GameObject thisObject = gameObject.GetComponent<ScriptPlay>().thisObject;
            thisObject.transform.position = Vector3.MoveTowards(thisObject.transform.position, targetOBJ.transform.position, speed);
        }
    }
}
