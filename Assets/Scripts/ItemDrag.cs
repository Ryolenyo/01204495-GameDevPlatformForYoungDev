using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IDragHandler , IEndDragHandler
{
    Vector3 FixPosition;
    public GameObject itemList;
    public GameObject model;
    private GameObject item;
    //For script part
    private AddingScript itemScript;
    public GameObject dropBox;
    public bool onDropArea;

    public GameObject scriptsPanel;
    private GameObject scp;
    //private GameObject scriptsManager;

    void Start()
    {
        onDropArea = false;
        FixPosition = transform.localPosition;
        itemList = GameObject.FindGameObjectWithTag("UI").transform.Find("ScenePanel").Find("ItemList").GetChild(0).GetChild(0).gameObject;

        //scriptsManager = GameObject.Find("ScriptsManager");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item == null)
        {
            //create item and script panel
            item = Instantiate(model, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            

            if (item.tag != "Object")
            {
                itemScript = item.GetComponent<AddingScript>();
                itemScript.currentItem = this;

                dropBox = GameObject.Find("Collider").transform.GetChild(0).gameObject;

                if (dropBox)
                {
                    dropBox.GetComponent<ScriptsManager>().currentScript = item;
                }
            }
            SetSortingLayer("UI");
        }
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
        pos.z = item.transform.position.z;
        item.transform.position = pos;
        //Debug.Log("x: "+transform.localPosition.x+" y: "+transform.localPosition.y+" z: "+transform.localPosition.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (item.tag != "Object" && onDropArea && GameObject.FindGameObjectWithTag("Selected") != null && dropBox.GetComponent<ScriptsManager>().correctType)
        {
            //script attaching
            item.transform.SetParent(dropBox.GetComponent<ScriptsManager>().scriptAttachedPoint.transform);
            itemScript.currentItem = null;

            //find slot in dropbox
            Transform slot = dropBox.GetComponent<ScriptsManager>().slot.transform;
            item.transform.localPosition = new Vector3(slot.localPosition.x, slot.localPosition.y, slot.localPosition.z);
                
            SlotAttachment currentSlot = slot.GetComponent<SlotAttachment>();
            currentSlot.attached = true;
            currentSlot.script = item;

            onDropArea = false;
        }
        else if (item.tag != "Object" && (!onDropArea || GameObject.FindGameObjectWithTag("Selected") == null || !dropBox.GetComponent<ScriptsManager>().correctType))
        {
            Destroy(item);
        }
        else if (item.tag == "Object" && onDropArea)
        {
            Destroy(item);
        }
        /*GameObject item = Instantiate(model, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        */
        //item.transform.SetParent(null);
        if (item)
        {
            SetSortingLayer("Object");
            transform.localPosition = FixPosition;
            if (item.tag == "Object")
            {
                itemList.GetComponent<ItemListAdder>().newItem = item;
                itemList.GetComponent<ItemListAdder>().itemName = model.name;

                //add item and script panel to scriptsmanager's list
                /*ScriptsManager scriptsManagerVariable = scriptsManager.GetComponent<ScriptsManager>();
                scriptsManagerVariable.itemList.Add(item);*/
                scp = Instantiate(scriptsPanel, new Vector3(0, 0, 0), Quaternion.identity);
                item.GetComponent<ScriptActive>().scriptBox = scp;
                //scriptsManagerVariable.panelList.Add(scp);
            }
        }
        
        item = null;
        if(dropBox)
        {
            dropBox.GetComponent<ScriptsManager>().currentScript = null;
        }
    }

    // Start is called before the first frame update
    private void SetSortingLayer(string layerName)
    {
        if (model.name == "Sepiroth Model")
        {
            foreach (Transform bone in item.transform.GetChild(0))
            {
                bone.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
            }
        }
        else
        {
            if (item.GetComponent<SpriteRenderer>())
            {
                item.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
            }
        }
    }
}