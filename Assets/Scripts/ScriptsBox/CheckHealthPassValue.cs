using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckHealthPassValue : MonoBehaviour
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
        Transform cheHealthbox = this.transform.parent.parent;
        CheckHealth cheHealthScript = cheHealthbox.GetComponent<CheckHealth>();

        if (this.name == "InputName")
            cheHealthScript.nameForHealth = this.GetComponent<InputField>().text;
        else if (this.name == "InputHealth")
            cheHealthScript.health = int.Parse(this.GetComponent<InputField>().text);
        else if (this.name == "InputSign")
            cheHealthScript.sign = this.GetComponent<InputField>().text;

    }

}
