using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingScript : MonoBehaviour
{
    public ItemDrag currentItem;
    public MouseDrag currentScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Collider")
        {
            if (currentScript)
            {
                currentScript.onDropArea = true;
                currentScript.dropBox = other.gameObject.transform.GetChild(0).gameObject;
            }
            else if (currentItem)
            {
                currentItem.onDropArea = true;
                currentItem.dropBox = other.gameObject.transform.GetChild(0).gameObject;
            }
            //Debug.Log("Enter");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.name);
        if (other.name == "Collider")
        {
            if (currentScript)
            {
                currentScript.onDropArea = false;
            }
            else if (currentItem)
            {
                currentItem.onDropArea = false;
            }
            //Debug.Log("Exit");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Collider")
        {
            if (currentScript)
            {
                currentScript.onDropArea = true;
                currentScript.dropBox = other.gameObject.transform.GetChild(0).gameObject;
            }
        }
    }
}
