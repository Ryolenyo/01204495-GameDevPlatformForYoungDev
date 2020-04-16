using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    private SlotAttachment whileCol;
    private SlotAttachment doCol;
    private bool played;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<ScriptPlay>().play)
        {
            whileCol = gameObject.transform.Find("whileCol").gameObject.GetComponent<SlotAttachment>();
            doCol = gameObject.transform.Find("doCol").gameObject.GetComponent<SlotAttachment>();
            if(whileCol && doCol)
            {
                if (!doCol.script.GetComponent<ScriptPlay>().thisObject || !whileCol.script.GetComponent<ScriptPlay>().thisObject)
                {
                    whileCol.script.GetComponent<ScriptPlay>().thisObject = gameObject.GetComponent<ScriptPlay>().thisObject;
                    doCol.script.GetComponent<ScriptPlay>().thisObject = gameObject.GetComponent<ScriptPlay>().thisObject;
                }

                whileCol.script.GetComponent<ScriptPlay>().play = true;
                if (whileCol.script.GetComponent<ScriptPlay>().outVal)
                {
                    doCol.script.GetComponent<ScriptPlay>().play = true;
                }
                else
                {
                    doCol.script.GetComponent<ScriptPlay>().play = false;
                }
            }
        }
        else
        {
            whileCol = gameObject.transform.Find("whileCol").gameObject.GetComponent<SlotAttachment>();
            doCol = gameObject.transform.Find("doCol").gameObject.GetComponent<SlotAttachment>();
            if (whileCol && doCol)
            {
                if (!doCol.script.GetComponent<ScriptPlay>().thisObject || !whileCol.script.GetComponent<ScriptPlay>().thisObject)
                {
                    whileCol.script.GetComponent<ScriptPlay>().thisObject = gameObject.GetComponent<ScriptPlay>().thisObject;
                    doCol.script.GetComponent<ScriptPlay>().thisObject = gameObject.GetComponent<ScriptPlay>().thisObject;
                }

                whileCol.script.GetComponent<ScriptPlay>().play = false;
                if (whileCol.script.GetComponent<ScriptPlay>().outVal)
                {
                    doCol.script.GetComponent<ScriptPlay>().play = false;
                }
                else
                {
                    doCol.script.GetComponent<ScriptPlay>().play = false;
                }
            }
        }
    }
}
