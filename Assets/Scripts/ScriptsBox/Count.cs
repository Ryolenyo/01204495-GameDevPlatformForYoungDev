using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    public float timeLeft;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<ScriptPlay>().play)
        {
            Debug.Log("Time left: " + timeLeft);
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                gameObject.GetComponent<ScriptPlay>().outVal = true;
                timeLeft = time;
                Debug.Log("Count = true");
            }
            else
            {
                gameObject.GetComponent<ScriptPlay>().outVal = false;
            }
        }
    }
}
