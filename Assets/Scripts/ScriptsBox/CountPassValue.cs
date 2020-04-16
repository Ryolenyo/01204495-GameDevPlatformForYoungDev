using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountPassValue : MonoBehaviour
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
        Transform countbox = this.transform.parent.parent;
        Count countTime = countbox.GetComponent<Count>();

        if (this.name == "InputKey")
        {
            countTime.time = float.Parse(this.GetComponent<InputField>().text);
            countTime.timeLeft = float.Parse(this.GetComponent<InputField>().text);
        }
    }

}
