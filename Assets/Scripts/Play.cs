using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public List<GameObject> scripts;
    public List<Vector3> scriptsPosition;
    public List<Vector3> scriptsRotation;

    public bool isPlay;
    public Sprite play;
    public Sprite pause;

    //GET [PLAYER CAMERA] FROM [CAMERADRAG] IN [CAMERA DROP BUTTON]
    public GameObject myCamera;

    // Start is called before the first frame update
    void Start()
    {
        isPlay = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchOn()
    {
        isPlay = !isPlay;
        if (isPlay)
        {
            GetComponent<Image>().sprite = pause;
        }
        else
        {
            GetComponent<Image>().sprite = play;
        }

        foreach (GameObject s in scripts)
        {
            saveValue(s);
            s.GetComponent<ScriptPanelPlay>().play = isPlay;
            
            /*Movement obj = s.GetComponent<Movement>();
            obj.playScript = true;
            Animator anim = obj.GetComponent<Animator>();
            if (anim)
            {
                anim.enabled = true;
            }*/
        }

        //ACTIVATE [PLAYER CAMERA]
        if (myCamera)
        {
            myCamera.transform.Find("PlayerCamera").gameObject.SetActive(isPlay);
            myCamera.transform.Find("CameraStandIn").gameObject.SetActive(!isPlay);
        }
    }

    void saveValue(GameObject s)
    {
        scriptsPosition.Add(s.GetComponent<ScriptPanelPlay>().thisObject.transform.position); //object position
        scriptsRotation.Add(s.GetComponent<ScriptPanelPlay>().thisObject.transform.rotation.eulerAngles); //object rotation
    }

    public void resetValue()
    {
        int i = 0;
        foreach(GameObject s in scripts)
        {
            s.GetComponent<ScriptPanelPlay>().thisObject.transform.position = scriptsPosition[i];
            s.GetComponent<ScriptPanelPlay>().thisObject.transform.localEulerAngles = scriptsRotation[i];
            i++;
        }
        //clear list
        scriptsPosition = new List<Vector3>();
        scriptsRotation = new List<Vector3>();


        GetComponent<Image>().sprite = play;

        foreach (GameObject s in scripts)
        {
            saveValue(s);
            s.GetComponent<ScriptPanelPlay>().play = false;
        }

    }
}