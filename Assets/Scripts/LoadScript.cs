using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScript : MonoBehaviour
{
    public GameObject script;
    public GameObject col;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadScriptToScene()
    {
        GameObject x = Instantiate(script);
        x.transform.position = new Vector3(80,0,90);
        x.GetComponent<MouseDrag>().onDropArea = true;
    }
}
