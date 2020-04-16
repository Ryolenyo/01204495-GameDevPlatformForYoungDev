using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsManager : MonoBehaviour
{
    public GameObject slot;
    public GameObject slotPrefab;

    public bool split;
    public GameObject splitPoint;

    public GameObject currentScript;
    public GameObject latest;
    public GameObject scriptAttachedPoint;

    public bool correctType;
    public bool onSelected;
    
    // Start is called before the first frame update
    void Start()
    {
        split = false;
        foreach (Transform child in gameObject.transform)
        {
            bool attached = child.GetComponent<SlotAttachment>().attached;
            if (!attached)
            {
                slot = child.gameObject;
                latest = slot;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SlotAttachment currentSlot = slot.GetComponent<SlotAttachment>();
        SlotAttachment latestSlot = latest.GetComponent<SlotAttachment>();
        if (currentScript)
        {
            if (currentSlot.gameObject.name == "whileCol" && currentScript.GetComponent<ScriptType>().type == ScriptType.Type.Argument)
            {
                correctType = true;
            }
            else if (currentSlot.gameObject.name != "whileCol" && currentScript.GetComponent<ScriptType>().type == ScriptType.Type.Action)
            {
                correctType = true;
            }
            else
            {
                correctType = false;
            }
        }

        if (currentSlot.attached)
        {
            if (slot == latest)
            {
                GameObject newSlot = Instantiate(slotPrefab, new Vector3(latestSlot.transform.position.x,
                    latest.transform.position.y - 8.5f, latestSlot.transform.position.z), Quaternion.identity, gameObject.transform);
                latestSlot.next = newSlot;
                SlotAttachment nextSlot = newSlot.GetComponent<SlotAttachment>();
                nextSlot.prev = latest;
                slot = newSlot;
                latest = slot;
            }
            else
            {
                slot = latest;
            }
            split = false;
            splitPoint = null;
        }
    }
}
