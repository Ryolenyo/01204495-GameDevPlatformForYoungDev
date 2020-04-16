using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementPassValue : MonoBehaviour
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
        Transform movementbox = this.transform.parent.parent;
        Movement movementScript = movementbox.GetComponent<Movement>();

        if (this.name == "InputPosX")
        {
            movementScript.velocityX = float.Parse(this.GetComponent<InputField>().text);
            Debug.Log("InputX: " + movementScript.velocityX);
        }
        else if (this.name == "InputPosY")
        {
            movementScript.velocityY = float.Parse(this.GetComponent<InputField>().text);
            Debug.Log("InputY: " + movementScript.velocityY);
        }
        else if (this.name == "InputPosZ")
        {
            movementScript.velocityZ = float.Parse(this.GetComponent<InputField>().text);
            Debug.Log("InputZ: " + movementScript.velocityZ);
        }
    }
}
