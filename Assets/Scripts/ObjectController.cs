using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public string objectName;
    public GameObject currentObject;
    public GameObject displayPanel;
    public GameObject posPanel;
    public GameObject rotPanel;
    public GameObject sizePanel;
    public GameObject gravPanel;

    // Start is called before the first frame update
    void Start()
    {
        objectName = null;
    }
    private void Update()
    {
        SetAttributePanel();
    }

    // Update is called once per frame
    public void SetAttributePanel()
    {
        if(objectName != null)
        {
            if(currentObject && currentObject.name != objectName)
            {
                currentObject.tag = "Object";
            }
            currentObject = GameObject.Find(objectName);
            currentObject.tag = "Selected";
            displayPanel.SetActive(true);
            
            List<InputField> fields;
            List<float> vals;
            //set position field
            GetFields(posPanel, out fields);
            GetValues(currentObject.transform.position, out vals);
            SetInputField(fields, vals);
            //set rotation field
            GetFields(rotPanel, out fields);
            GetValues(currentObject.transform.rotation.eulerAngles, out vals);
            SetInputField(fields, vals);
            //set size field
            GetFields(sizePanel, out fields);
            GetValues(currentObject.transform.localScale, out vals);
            SetInputField(fields, vals);
            //set gravity field
            Toggle gravTog = gravPanel.GetComponentInChildren<Toggle>();
            Rigidbody rigidbody = currentObject.GetComponent<Rigidbody>();
            gravTog.isOn = false;
            if (rigidbody)
            {
                gravTog.isOn = rigidbody.useGravity;
            }
        }
        else
        {
            displayPanel.SetActive(false);
            if (currentObject)
            {
                currentObject.tag = "Object";
            }
        }
    }

    void GetFields(GameObject gameObjs, out List<InputField> fields)
    {
        fields = new List<InputField>();
        foreach(Transform gameObj in gameObjs.transform)
        {
            fields.Add(gameObj.GetComponent<InputField>());
        }
    }
    void GetValues(Vector3 trans, out List<float> vals)
    {
        vals = new List<float>();
        vals.Add(trans.x);
        vals.Add(trans.y);
        vals.Add(trans.z);
    }

    void SetInputField(List<InputField> fields, List<float> vals)
    {
        for(int i = 0; i < 3; i++)
        {
            fields[i].text = vals[i].ToString("#.00");
        }
    }
}
