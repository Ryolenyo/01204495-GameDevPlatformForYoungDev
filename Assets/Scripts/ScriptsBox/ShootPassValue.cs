using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootPassValue : MonoBehaviour
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
        Transform shootbox = this.transform.parent.parent;
        Shoot shootScript = shootbox.GetComponent<Shoot>();

        if (this.name == "InputPosX")
        {
            shootScript.velocityX = float.Parse(this.GetComponent<InputField>().text);
            Debug.Log("InputX: " + shootScript.velocityX);
        }
        else if (this.name == "InputPosY")
        {
            shootScript.velocityY = float.Parse(this.GetComponent<InputField>().text);
            Debug.Log("InputY: " + shootScript.velocityY);
        }
        else if (this.name == "InputPosZ")
        {
            shootScript.velocityZ = float.Parse(this.GetComponent<InputField>().text);
            Debug.Log("InputZ: " + shootScript.velocityZ);
        }
    }
}
