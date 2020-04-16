using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptActive : MonoBehaviour
{
    public GameObject scriptBox;
    public GameObject dropArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!scriptBox.GetComponent<ScriptPanelPlay>().thisObject)
        {
            scriptBox.GetComponent<ScriptPanelPlay>().thisObject = gameObject;
        }

        dropArea = GameObject.Find("Collider");
        if (gameObject.tag == "Selected" && scriptBox && dropArea)
        {
            scriptBox.transform.SetParent(dropArea.transform);
            scriptBox.GetComponent<ScriptsManager>().onSelected = true;
            //scriptBox.SetActive(true);
            scriptBox.transform.localPosition = new Vector3(0,200,0);
        }
        else if (scriptBox)
        {
            scriptBox.transform.SetParent(null);
            scriptBox.GetComponent<ScriptsManager>().onSelected = false;
            //scriptBox.SetActive(false);
        }
    }
}
