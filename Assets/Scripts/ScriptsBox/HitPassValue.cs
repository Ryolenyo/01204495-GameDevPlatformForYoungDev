using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPassValue : MonoBehaviour
{
    public GameObject target;
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
        Transform hitBox = this.transform.parent.parent;
        Hit hitScript = hitBox.GetComponent<Hit>();
        hitScript.target = this.GetComponent<InputField>().text;
    }
}
