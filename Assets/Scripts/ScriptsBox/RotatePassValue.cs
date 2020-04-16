using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatePassValue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeInputValue()
    {
        Transform rotatebox = this.transform.parent.parent;
        Rotate rotateScript = rotatebox.GetComponent<Rotate>();

        if (this.name == "InputRotX")
            rotateScript.rotateX = float.Parse(this.GetComponent<InputField>().text);
        else if (this.name == "InputRotY")
            rotateScript.rotateY = float.Parse(this.GetComponent<InputField>().text);
        else if (this.name == "InputRotZ")
            rotateScript.rotateZ = float.Parse(this.GetComponent<InputField>().text);
    }
}
