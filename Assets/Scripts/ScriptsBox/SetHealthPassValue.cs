using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHealthPassValue : MonoBehaviour
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
        Transform healthbox = this.transform.parent.parent;
        SetHealth healthScript = healthbox.GetComponent<SetHealth>();

        if (this.name == "InputName")
            healthScript.nameForHealth = this.GetComponent<InputField>().text; 
        else if (this.name == "InputHealth")
            healthScript.health = int.Parse(this.GetComponent<InputField>().text);

    }


}
