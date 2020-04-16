using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShowAttribute : MonoBehaviour
{
    public GameObject objectSystem;

    private void Start()
    {
        objectSystem = GameObject.Find("ObjectSystem");
    }

    public void ShowAttribute()
    {
        GameObject selectedObject = GameObject.Find(name);
        Debug.Log(GetComponentInChildren<Text>().text.Trim(' '));
        if (selectedObject)
        {
            objectSystem.GetComponent<ObjectController>().objectName = selectedObject.name;

        }
    }
}