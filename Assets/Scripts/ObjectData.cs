using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class PrefabData
{
    public string name;
    public float posX;
    public float posY;
    public float posZ;
    public float rotX;
    public float rotY;
    public float rotZ;
    public float sizeX;
    public float sizeY;
    public float sizeZ;
    public bool grav;
    public List<string> slot = new List<string>();
    public List<string> scriptSlot = new List<string>();
}


[Serializable]
public class ObjectData : MonoBehaviour
{

    private GameObject itemContent;

    [SerializeField]
    public List<PrefabData> prefabData = new List<PrefabData>();

    public GameObject[] Obj;
    public GameObject ScriptPanel;
    public GameObject slot;
    public GameObject[] scriptList;

    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "TestLoad")
        {
            load();
            Debug.Log("hey");
        }
    }

    public void save()
    {
        itemContent = GameObject.Find("ContentForJSON");

        ItemListAdder itemVariable = itemContent.GetComponent<ItemListAdder>();
        List<GameObject> itemList = itemVariable.itemGOList;

        foreach (GameObject item in itemList)
        {
            PrefabData x = new PrefabData();
            x.name = item.name;
            //save position
            x.posX = item.transform.position.x;
            x.posY = item.transform.position.y;
            x.posZ = item.transform.position.z;
            //save rotation
            x.rotX = item.transform.rotation.x;
            x.rotY = item.transform.rotation.y;
            x.rotZ = item.transform.rotation.z;
            //save scale
            x.sizeX = item.transform.localScale.x;
            x.sizeY = item.transform.localScale.y;
            x.sizeZ = item.transform.localScale.z;
            //save grav --> need to be set soon !!!!!
            x.grav = false;
            //save slot
            ScriptActive sa = item.GetComponent<ScriptActive>(); //find ScriptPanel of this obj
            GameObject sp = sa.scriptBox; //Script panel
            foreach(Transform child in sp.transform)
            {
                if (child.name == "Slot" || child.name == "Slot(Clone)")
                {
                    Debug.Log("YEE");
                    //this is slot
                    x.slot.Add(child.name);
                    Debug.Log("YEET");
                    //this is its script
                    if (child.GetComponent<SlotAttachment>().script)
                    {
                        SlotAttachment sac = child.GetComponent<SlotAttachment>();
                        x.scriptSlot.Add(sac.script.name);
                    }
                }
            }



            prefabData.Add(x);
        }

        Debug.Log(prefabData);

        string json = JsonUtility.ToJson(this); //this = this Script
        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
        Debug.Log(json);

    }

    public void load()
    {

        string encodedString = File.ReadAllText(Application.dataPath + "/saveFile.json");
        JSONObject inpObject = new JSONObject(encodedString);

        PrefabData inpData = new PrefabData();
        GameObject forTemp = new GameObject();

        for (int i = 0; i < 10; i++)
        {
            //each Data [0]=name [1,2,3]=position [4]=grav;

            if (inpObject[0][i][0]!=null)
            {

                string name = inpObject[0][i][0].Print();
                //set position
                float px = inpObject[0][i][1].n;
                float py = inpObject[0][i][2].n;
                float pz = inpObject[0][i][3].n;
                //set rotation
                float rx = inpObject[0][i][4].n;
                float ry = inpObject[0][i][5].n;
                float rz = inpObject[0][i][6].n;
                // set scale
                float sx = inpObject[0][i][7].n;
                float sy = inpObject[0][i][8].n;
                float sz = inpObject[0][i][9].n;
                // set grav
                float grav = inpObject[0][i][10].n;

                //clear name
                string tempName = name;
                tempName = name.Replace("\"","");
                name = tempName;
                tempName = name.Replace("(", "");
                name = tempName;
                tempName = name.Replace(")", "");
                name = tempName;
                for (int zz = 0 ; zz < 10 ; zz++)
                {
                    tempName = name.Replace(zz.ToString(), "");
                    name = tempName;
                }

                for (int c = 0; c < 10; c++)
                {
                    if (name == "Floor")
                    {
                        forTemp = Obj[0];
                    }
                    else if (name == "Trees")
                    {
                        forTemp = Obj[1];
                    }
                    else if (name == "Sepiroth Model")
                    {
                        forTemp = Obj[2];
                    }
                    else
                    {
                        break;
                    }
                }

                //temp = Object
                GameObject temp = Instantiate(forTemp) as GameObject;
                temp.transform.position = new Vector3(px, py, pz);
                temp.transform.eulerAngles = new Vector3(rx, ry, rz);
                temp.transform.localScale = new Vector3(sx, sy, sz);
                //Link Script Panel to Object
                GameObject sp = Instantiate(ScriptPanel) as GameObject;
                ScriptActive sa = temp.GetComponent<ScriptActive>();
                sa.scriptBox = sp;
                //set grav


                //Add slot and Script to Panel
                int j = 0;

                while (inpObject[0][i][12][j]) // check scriptSlot if (it == null) -> stop
                {
                    //clear name
                    string word = inpObject[0][i][12][j].Print();
                    string wordCut = word.Replace("(Clone)","");
                    word = wordCut;
                    wordCut = word.Replace("\"","");
                    word = wordCut;

                    //script
                    int choose = 0;
                    if (wordCut == "Scriptbox_Button")
                    {
                        choose = 0;
                    }
                    else if (wordCut == "Scriptbox_Movement")
                    {
                        choose = 1;
                    }
                    else if (wordCut == "Scriptbox_While")
                    {
                        choose = 2;
                    }
                    else
                    {

                    }

                    if (j==1) //first
                    {
                        //add script
                        GameObject script = Instantiate(scriptList[choose],sp.transform); // create script from name and set its parent (scriptbox)
                    }
                    else
                    {
                        //add prev slot
                        //add script
                        GameObject slotNow = Instantiate(slot, sp.transform);
                        GameObject script = Instantiate(scriptList[choose], sp.transform); // create script from name and set its parent (scriptbox)
                    }
                    //add slot
                    GameObject slotLast = Instantiate(slot, sp.transform);
                    j++;
                }

            }
            else
            {
                break;
            }

            for (int j = 0; j < 5; j++)
            {
                /*
                if (inpObject[0][i][j])
                {
                    Debug.Log(inpObject[0][i][j]);
                }
                else
                {
                    break;
                }
                */
            }
        }
    }
}
