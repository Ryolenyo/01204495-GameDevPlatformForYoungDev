using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSave : MonoBehaviour
{
    GameObject myObject;
    GameObject myPanel;

    //slot of scripts
    public GameObject[] slotScripts;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void saveAttribute()
    {
        //Find seleted obj
        myObject = GameObject.FindGameObjectWithTag("Selected");
        MyScript myScriptVariable = myObject.GetComponent<MyScript>();

        //Find obj panel in obj
        ScriptActive myPanelVariable = myObject.GetComponent<ScriptActive>();
        myPanel =  myPanelVariable.scriptBox;


        //This part should generate or sent something to [MyScript.cs] of [seleted object(myObject)]

        foreach (Transform obj in myPanel.transform)
        {
            
            if (obj.name == "Slot" || obj.name == "Slot(Clone)")
            {
                SlotAttachment slotVariable = obj.GetComponent<SlotAttachment>();
                if (slotVariable.script)
                {
                    GameObject slotScripts = slotVariable.script;
                    Debug.Log("FOUND: " + slotScripts.name);

                    /////////sent SCRIPTS to OBJ down here////////



                }
                else
                {
                    break;
                }

            }
        }

        myScriptVariable.isResetScript = true;
    }
}
