using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScriptDrag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector3 FixPosition;
    GameObject myObject;

    public bool onDropArea;
    public GameObject model;

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
        pos.z = transform.position.z;
        transform.position = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (onDropArea && GameObject.FindGameObjectWithTag("Selected")!=null)
        {
            Instantiate(model, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, myObject.transform);
        }
        transform.localPosition = FixPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        FixPosition = transform.localPosition;
        onDropArea = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Collider")
        {
            onDropArea = true;
            myObject = other.gameObject;
            //Debug.Log("Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Collider")
        {
            onDropArea = false;
            //Debug.Log("Exit");
        }
    }


}
