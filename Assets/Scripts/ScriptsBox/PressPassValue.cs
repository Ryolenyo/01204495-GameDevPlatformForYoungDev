using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressPassValue : MonoBehaviour
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
        Transform pressbox = this.transform.parent.parent;
        Press PressScript = pressbox.GetComponent<Press>();

        if (this.name == "InputKey")
            PressScript.button = this.GetComponent<InputField>().text;

    }
}
