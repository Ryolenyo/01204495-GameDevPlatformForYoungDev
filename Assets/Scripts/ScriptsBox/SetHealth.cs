using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHealth : MonoBehaviour
{
    public bool playScript = false;
    public int health;
    public string nameForHealth;
    public GameObject healthPrefab;
    public bool isSet;

    // Start is called before the first frame update
    void Start()
    {
        isSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<ScriptPlay>().play)
        {
            if (!isSet)
            {
                GameObject objHealth = Instantiate(healthPrefab);
                objHealth.name = nameForHealth;
                objHealth.GetComponent<Health>().myHealth = health;
                isSet = true;
            }
        }
        else
        {
            isSet = false;
            if (GameObject.Find(nameForHealth))
            {
                Destroy(GameObject.Find(nameForHealth));
            }
        }
    }
}
