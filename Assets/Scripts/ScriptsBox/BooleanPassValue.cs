using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BooleanPassValue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToggleValue()
    {
        Transform boolBox = this.transform.parent.parent;
        Boolean boolScript = boolBox.GetComponent<Boolean>();
        boolScript.fromPass = this.GetComponent<Toggle>().isOn;
    }
}
