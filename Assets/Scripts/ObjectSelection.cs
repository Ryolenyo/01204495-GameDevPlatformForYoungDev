using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public float rayLength;
    public LayerMask layerMask;
    public GameObject objectSystem;
    public GameObject itemList;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, layerMask))
            {
                if (hit.collider.name != null)
                {
                    objectSystem.GetComponent<ObjectController>().objectName = hit.collider.name;
                    //objectSystem.GetComponent<ObjectController>().SetAttributePanel();
                    if (itemList)
                    {
                        foreach (Transform item in itemList.transform)
                        {
                            if (item.name == hit.collider.name)
                            {
                                Debug.Log(item.name);
                                //item.GetComponent<Button>().onClick();
                            }
                        }
                    }
                }
            }
            else
            {
                if (objectSystem)
                {
                    objectSystem.GetComponent<ObjectController>().objectName = null;
                    //objectSystem.GetComponent<ObjectController>().SetAttributePanel();
                }
            }
        }
    }
}
