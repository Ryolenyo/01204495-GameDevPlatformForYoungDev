

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnScene : MonoBehaviour
{
    public float speed = 3.5f;
    public float camera1 = 5f;
    public float camera2 = 5f;
    private float X;
    private float Y;


    void Update()
    {
        if (Input.GetMouseButton(1)) //CLICK RIGHT TO ROTATE CAMERA
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }
        if (Input.GetMouseButton(2)) //CLICK SCROLL WHEEL TO MOVE CAMERA
        {
            transform.position = new Vector3(transform.position.x - Input.GetAxis("Mouse X") * speed, transform.position.y - Input.GetAxis("Mouse Y") * speed);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y - camera1, transform.position.z + camera2);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + camera1, transform.position.z - camera2);
        }

    }

    // ACTIVATE WHEN PRESS "Reset" BUTTON TO RESET CAMERA
    public void Reset()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Selected");
        Debug.Log(obj.name);
        transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z-150);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
