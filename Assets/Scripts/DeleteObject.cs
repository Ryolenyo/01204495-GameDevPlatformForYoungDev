using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    public GameObject content;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Delete()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Selected");
        Destroy(obj.GetComponent<ScriptActive>().scriptBox);

        foreach(Transform x in content.transform)
        {
            if (x.name == obj.name)
            {
                Destroy(x.gameObject);
                break;
            }
        }
        Destroy(obj);
    }
}
