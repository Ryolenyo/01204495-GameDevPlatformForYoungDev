using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPassValue : MonoBehaviour
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
        Transform followbox = this.transform.parent.parent;
        Follow followScript = followbox.GetComponent<Follow>();

        if (this.name == "InputName")
            followScript.target = this.GetComponent<InputField>().text;
        else if (this.name == "InputSpeed")
            followScript.speed = float.Parse(this.GetComponent<InputField>().text);

    }
}
