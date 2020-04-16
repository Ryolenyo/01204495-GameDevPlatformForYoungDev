using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectChanged : MonoBehaviour
{
    public GameObject currentObject;

    // Start is called before the first frame update
    public void ChangeInputValue()
    {
        currentObject = GameObject.FindGameObjectWithTag("Selected");
        Transform currentTransform = currentObject.transform;
        Vector3 pos = currentTransform.position;
        Vector3 rot = currentTransform.eulerAngles;
        Vector3 size = currentTransform.localScale;

        if (this.name == "InputPosX")
            pos.x = float.Parse(this.GetComponent<InputField>().text);
        else if (this.name == "InputPosY")
            pos.y = float.Parse(this.GetComponent<InputField>().text);
        else if (this.name == "InputPosZ")
            pos.z = float.Parse(this.GetComponent<InputField>().text);
        else if (this.name == "InputRotX")
            rot.x = float.Parse(this.GetComponent<InputField>().text);
        else if (this.name == "InputRotY")
            rot.y = float.Parse(this.GetComponent<InputField>().text);
        else if (this.name == "InputRotZ")
            rot.z = float.Parse(this.GetComponent<InputField>().text);
        else if (this.name == "InputSizeX")
        {
            size.x = float.Parse(this.GetComponent<InputField>().text);
        }
        else if (this.name == "InputSizeY")
            size.y = float.Parse(this.GetComponent<InputField>().text);
        else if (this.name == "InputSizeZ")
            size.z = float.Parse(this.GetComponent<InputField>().text);

        currentTransform.position = pos;
        currentTransform.eulerAngles = rot;
        currentTransform.localScale = size;
    }
    public void ChangeToggleValue()
    {
        currentObject = GameObject.FindGameObjectWithTag("Selected");
        Rigidbody currentRigid = currentObject.GetComponent<Rigidbody>();
        currentRigid.useGravity = this.GetComponent<Toggle>().isOn;
    }
}
