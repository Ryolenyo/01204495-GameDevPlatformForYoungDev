using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHealthPassValue : MonoBehaviour
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
        Transform chHealthbox = this.transform.parent.parent;
        ChangeHealth chHealthScript = chHealthbox.GetComponent<ChangeHealth>();

        if (this.name == "InputName")
            chHealthScript.nameForHealth = this.GetComponent<InputField>().text;
        else if (this.name == "InputHealth")
            chHealthScript.health = int.Parse(this.GetComponent<InputField>().text);

    }

}
