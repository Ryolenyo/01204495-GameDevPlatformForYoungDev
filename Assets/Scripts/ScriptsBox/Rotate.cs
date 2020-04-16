using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateX;
    public float rotateY;
    public float rotateZ;

    private bool played;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<ScriptPlay>().play)
        {
            GameObject thisObject = gameObject.GetComponent<ScriptPlay>().thisObject;
            thisObject.transform.Rotate(new Vector3(rotateX,rotateY,rotateZ));
        }
    }
}
