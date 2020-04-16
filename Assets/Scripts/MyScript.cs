using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    public GameObject myScriptBox;
    public bool isResetScript;
    GameObject playManager;

    //List of Script
    public List<GameObject> ScriptsList;


    // Start is called before the first frame update
    void Start()
    {
        isResetScript = false;
        playManager = GameObject.Find("PlayManagerButton");
        ScriptsList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //Active when save button is pressed
        if (isResetScript)
        {
            foreach (Transform eachChild in myScriptBox.transform)
            {
                if (eachChild.name == "Scriptbox_Movement(Clone)")
                {
                    Movement newScript = gameObject.AddComponent<Movement>();
                    Movement childScript = eachChild.GetComponent<Movement>();

                    Play p = playManager.GetComponent<Play>();
                    p.scripts.Add(gameObject);

                    newScript.velocityX = childScript.velocityX;
                    newScript.velocityY = childScript.velocityY;
                    newScript.velocityZ = childScript.velocityZ;

                    eachChild.gameObject.SetActive(false);

                }
            }
            isResetScript = false;
        }
    }
}
