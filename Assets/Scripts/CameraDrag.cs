using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraDrag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector3 FixPosition;
    public GameObject itemList;
    public GameObject model;
    private GameObject item;
    //For script part
    private AddingScript itemScript;
    public GameObject dropBox;
    public bool onDropArea;
    //FPS TPS variable
    public GameObject myCamera;
    public GameObject myParent;
    public bool isFollow;
    //play part
    public GameObject playButton;

    void Start()
    {
        onDropArea = false;
        isFollow = false;
        FixPosition = transform.localPosition;
        itemList = GameObject.FindGameObjectWithTag("UI").transform.Find("ScenePanel").Find("ItemList").GetChild(0).GetChild(0).gameObject;

    }

    void Update()
    {
        if (isFollow) 
        {
            myParent = GameObject.FindGameObjectWithTag("Selected");
            if (myParent)
            {
                Debug.Log(myParent.name);
            }
            myCamera.transform.parent = myParent.transform;
            isFollow = false;
        }
    }

    //FPS TPS setting
    public void cameraSet(bool isReady)
    {
        isFollow = isReady;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item == null)
        {
            //create item and script panel
            item = Instantiate(model, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            myCamera = item;

            //Assign camera to play button
            Play playVariable = playButton.GetComponent<Play>();
            playVariable.myCamera = myCamera;

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
        if (item.tag != "Object" && onDropArea && GameObject.FindGameObjectWithTag("Selected") != null)
        {
            //script attaching
            item.transform.SetParent(dropBox.transform);
            itemScript.currentItem = null;
        }
        else if (item.tag != "Object" && (!onDropArea || GameObject.FindGameObjectWithTag("Selected") == null))
        {
            Destroy(item);
        }
        else if (item.tag == "Object" && onDropArea)
        {
            Destroy(item);
        }

        if (item)
        {
            SetSortingLayer("Object");
            transform.localPosition = FixPosition;
            if (item.tag == "Object")
            {
                itemList.GetComponent<ItemListAdder>().newItem = item;
                itemList.GetComponent<ItemListAdder>().itemName = model.name;
            }
        }

        item = null;
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
