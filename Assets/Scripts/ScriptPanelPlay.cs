using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPanelPlay : MonoBehaviour
{
    public bool play;
    public GameObject playButton;
    public GameObject thisObject;

    // Start is called before the first frame update
    void Start()
    {
        playButton = GameObject.Find("PlayManagerButton");
        playButton.GetComponent<Play>().scripts.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform slot in gameObject.transform)
        {
            if (slot.GetComponent<SlotAttachment>())
            {
                GameObject slotScript = slot.gameObject.GetComponent<SlotAttachment>().script;
                if (slotScript)
                {
                    if (play)
                    {
                        slotScript.GetComponent<ScriptPlay>().play = true;
                        slotScript.GetComponent<ScriptPlay>().thisObject = thisObject;
                    }
                    else if (!play)
                    {
                        slotScript.GetComponent<ScriptPlay>().play = false;
                    }
                }
            }
        }
    }
}
