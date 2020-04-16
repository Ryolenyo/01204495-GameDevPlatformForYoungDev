using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public bool isLose;
    public bool isSet;
    public GameObject Lose;
    public GameObject Win;
    private GameObject TempUI;
    private GameObject init;

    // Start is called before the first frame update
    void Start()
    {
        isSet = true;
        TempUI = GameObject.Find("TempUI");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<ScriptPlay>().play)
        {
            if (isSet)
            {
                if (isLose)
                {
                    init = Instantiate(Lose, TempUI.transform);
                    //Set something maybe playScript = false;
                }
                else
                {
                    init = Instantiate(Win, TempUI.transform);
                    //Set something maybe playScript = false;
                }
                isSet = false; //for init once
            }
        }
        else
        {
            isSet = true;
            Destroy(init);
        }
    }
}
