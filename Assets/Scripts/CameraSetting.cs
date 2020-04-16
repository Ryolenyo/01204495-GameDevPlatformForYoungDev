using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    public bool closeSetting;
    public GameObject cameraSetting;
    // Start is called before the first frame update
    void Start()
    {
        closeSetting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (closeSetting)
        {
            cameraSetting.SetActive(false);
        }
        else
        {
            cameraSetting.SetActive(true);
        }

    }

    public void ToggleCameraMenu()
    {
        closeSetting = !closeSetting;
    }
}
