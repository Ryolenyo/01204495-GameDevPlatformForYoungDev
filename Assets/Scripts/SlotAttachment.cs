using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotAttachment : MonoBehaviour
{
    public bool attached;
    public bool resize;
    public GameObject script;
    public GameObject prev;
    public GameObject next;
    public ScriptsManager scriptsManager;

    public float disX = 25;
    public float disY = 8;

    // Start is called before the first frame update
    void Start()
    {
        attached = false;
        resize = false;

        Debug.Log("NAME: " + gameObject.name);

        if (gameObject.name == "whileCol" || gameObject.name == "doCol")
        {
            Debug.Log("found: "+gameObject.name);
            scriptsManager = transform.parent.parent.GetComponent<ScriptsManager>();
        }
        else
        {
            Debug.Log("found: " + gameObject.name);
            scriptsManager = GetComponentInParent<ScriptsManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(scriptsManager.slot == gameObject)
        {
            scriptsManager.scriptAttachedPoint = transform.parent.gameObject;
        }

        //Resizing slot
        if (script)
        {
            BoxCollider slotCollider = GetComponent<BoxCollider>();
            BoxCollider scriptCollider = script.GetComponent<BoxCollider>();
            
            if (slotCollider.size.y != scriptCollider.size.y || resize)
            {
                Resizing(script);
            }

            if(scriptsManager && scriptsManager.onSelected)
            {
                script.GetComponent<Canvas>().enabled = true;
            }
            else if(!scriptsManager.onSelected)
            {
                script.GetComponent<Canvas>().enabled = false;
            }
        }

        //Slide script up
        if (attached && script)
        {
            if (Mathf.Abs(script.transform.position.x - gameObject.transform.position.x) > disX 
                || Mathf.Abs(script.transform.position.y - gameObject.transform.position.y) > disY)
            {
                SlotAttachment nextSlot = next.GetComponent<SlotAttachment>();
                if (nextSlot.script)
                {
                    SlideUpScript(nextSlot);
                }
                else
                {
                    SetCurrentSlot();
                }
            }
        }
        else if(attached && !script)
        {
            SlotAttachment nextSlot = next.GetComponent<SlotAttachment>();
            if (nextSlot.script)
            {
                SlideUpScript(nextSlot);
            }
            else
            {
                SetCurrentSlot();
            }
        }

        //while & if
        if (script)
        {
            GameObject whileCol = script.transform.Find("whileCol").gameObject;
            GameObject doCol = script.transform.Find("doCol").gameObject;

            SlotAttachment whileSlot = whileCol.GetComponent<SlotAttachment>();
            SlotAttachment doSlot = doCol.GetComponent<SlotAttachment>();

            if(!whileSlot)
            {
                whileSlot = whileCol.AddComponent<SlotAttachment>();
            }
            if(!doSlot)
            {
                doSlot = doCol.AddComponent<SlotAttachment>();
            }

            if (whileCol || doCol && scriptsManager.currentScript)
            {
                float whileY = Mathf.Abs(whileCol.transform.position.y - scriptsManager.currentScript.transform.position.y);
                float whileX = Mathf.Abs(whileCol.transform.position.x - scriptsManager.currentScript.transform.position.x);
                float doY = Mathf.Abs(doCol.transform.position.y - scriptsManager.currentScript.transform.position.y);
                float doX = Mathf.Abs(doCol.transform.position.x - scriptsManager.currentScript.transform.position.x);

                if ((whileY <= 5 && whileX <= 15) && ((doY > 5 && doX > 15) || whileY < doY))
                {
                    Debug.Log("Entering while collider");
                    scriptsManager.slot = whileCol;
                }
                else if ((doY <= 5 && doX <= 15) && ((whileY > 5 && whileX > 15) || whileY > doY))
                {
                    Debug.Log("Entering do collider");
                    scriptsManager.slot = doCol;
                }
                else
                {
                    Debug.Log("Exiting while collider");
                    scriptsManager.slot = scriptsManager.latest;
                }
            }
        }

        //init new script in between old ones 
        /*ScriptsManager scriptsManager = GetComponentInParent<ScriptsManager>();
        GameObject currentScript = scriptsManager.currentScript;
        float diffY = Mathf.Abs(transform.position.y - currentScript.transform.position.y);
        float diffX = Mathf.Abs(transform.position.x - currentScript.transform.position.x);
        if (script && currentScript && gameObject != scriptsManager.slot
            && diffY <= disY && diffX <= disX && transform.position.y < currentScript.transform.position.y)
        {
            scriptsManager.split = true;
            scriptsManager.splitPoint = gameObject;
        }
        /*else if (gameObject == scriptsManager.slot && gameObject != scriptsManager.latest && (diffY > disY || diffX > disX))
        {
            scriptsManager.split = false;
        }

        if (!scriptsManager.split && scriptsManager.splitPoint)
        {
            if (transform.position.y <= scriptsManager.splitPoint.transform.position.y)
            {
                if (next)
                {
                    SlotAttachment nextSlot = next.GetComponent<SlotAttachment>();
                    SlideUpScript(nextSlot);
                }
                else
                {
                    SetCurrentSlot();
                }

                if (gameObject == scriptsManager.splitPoint)
                {
                    attached = true;
                    scriptsManager.splitPoint = null;
                }
            }
        }

        if(scriptsManager.split && scriptsManager.splitPoint  && currentScript)
        {
            if(prev && scriptsManager.splitPoint != gameObject && transform.position.y < currentScript.transform.position.y)
            {
                SlideDownScript();
                Resizing(script);
            }
            else if(scriptsManager.splitPoint == gameObject)
            {
                attached = false;
                scriptsManager.slot = gameObject;
                Resizing(currentScript);
            }
        }*/
    }

    private void Resizing(GameObject script)
    {
        BoxCollider slotCollider = GetComponent<BoxCollider>();
        BoxCollider scriptCollider = script.GetComponent<BoxCollider>();

        if (next)
        {
            SlotAttachment nextSlot = next.GetComponent<SlotAttachment>();
            nextSlot.resize = true;
        }
        Debug.Log("Resizing: " + script.name);

        transform.localScale = new Vector3(script.transform.localScale.x, script.transform.localScale.y, script.transform.localScale.z);
        float temp = slotCollider.size.y;
        slotCollider.size = new Vector3(slotCollider.size.x, scriptCollider.size.y, slotCollider.size.z);

        if (prev)
        {
            BoxCollider prevCollider = prev.GetComponent<BoxCollider>();
            transform.localPosition = new Vector3(transform.localPosition.x,
                prev.transform.localPosition.y - 1.5f - (slotCollider.size.y * transform.localScale.y + prevCollider.size.y * prev.transform.localScale.y) / 2,
                transform.localPosition.z);
            SetScriptPosition();
        }
        else
        {
            if (temp <= scriptCollider.size.y)
            {
                transform.localPosition = new Vector3(transform.localPosition.x,
                    transform.localPosition.y - Mathf.Abs(slotCollider.size.y - temp) * transform.localScale.y / 2,
                    transform.localPosition.z);
            }
            else
            {
                transform.localPosition = new Vector3(transform.localPosition.x,
                    transform.localPosition.y + Mathf.Abs(slotCollider.size.y - temp) * transform.localScale.y / 2,
                    transform.localPosition.z);
            }
            SetScriptPosition();
        }
        resize = false;
    }

    private void SlideUpScript(SlotAttachment nextSlot)
    {
        /*Debug.Log("Bye: " + script.name);
        Debug.Log("Slide up: " + nextSlot.script.name);*/
        script = nextSlot.script;
        SetScriptPosition();
        nextSlot.script = null;
    }

    private void SlideDownScript()
    {
        SlotAttachment prevSlot = prev.GetComponent<SlotAttachment>();
        if (prevSlot.script)
        {
            script = prevSlot.script;
            SetScriptPosition();
            if (!prevSlot.attached)
            {
                prevSlot.script = null;
            }
        }
    }

    private void SetCurrentSlot()
    {
        //Debug.Log("Set new slot");
        attached = false;
        script = null;
        if (next)
        {
            Destroy(next);
            next = null;
        }
        gameObject.GetComponentInParent<ScriptsManager>().slot = gameObject; 
        gameObject.GetComponentInParent<ScriptsManager>().latest = gameObject;
    }

    private void SetScriptPosition()
    {
        script.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    }
}