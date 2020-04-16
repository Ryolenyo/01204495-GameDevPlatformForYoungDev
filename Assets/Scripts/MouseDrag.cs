using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MouseDrag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    RaycastHit hit;

    private AddingScript itemScript;
    public bool onDropArea;
    public GameObject dropBox;
    void Start()
    {
        hit = new RaycastHit();
    }
    // Start is called before the first frame update
    /*private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        objectPos.z = transform.position.z;
        transform.position = objectPos;
    }*/
    void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 objectPos;

        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            objectPos = new Vector3(hit.point.x, hit.point.y, transform.position.z);
        }
        else
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
            objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            objectPos.z = transform.position.z;
        }
        transform.position = objectPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.SetParent(null);

        itemScript = gameObject.GetComponent<AddingScript>();
        itemScript.currentScript = this;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
        pos.z = transform.position.z;
        transform.position = pos;
        if (dropBox)
        {
            dropBox.GetComponent<ScriptsManager>().currentScript = gameObject;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (onDropArea && dropBox.GetComponent<ScriptsManager>().correctType)
        {
            //Attach with dropbox ("Collider")
            gameObject.transform.SetParent(dropBox.GetComponent<ScriptsManager>().scriptAttachedPoint.transform);

            //find slot in dropbox
            Transform slot = dropBox.GetComponent<ScriptsManager>().slot.transform;
            gameObject.transform.localPosition = new Vector3(slot.localPosition.x, slot.localPosition.y, slot.localPosition.z);
            
            SlotAttachment slotAvail = slot.GetComponent<SlotAttachment>();
            slotAvail.attached = true;
            slotAvail.script = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
        itemScript.currentScript = null;
        dropBox.GetComponent<ScriptsManager>().currentScript = null;
    }
}