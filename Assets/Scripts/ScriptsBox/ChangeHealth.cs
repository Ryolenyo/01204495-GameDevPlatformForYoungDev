using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHealth : MonoBehaviour
{
    public int health;
    public string nameForHealth;

    private int orgHealth = 0;
    private bool checkedHealth = false;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if(orgHealth == 0 && !checkedHealth)
        {
            if(GameObject.Find(nameForHealth).GetComponent<Health>())
            {
                orgHealth = GameObject.Find(nameForHealth).GetComponent<Health>().myHealth;
                checkedHealth = true;
            }
        }

        if (gameObject.GetComponent<ScriptPlay>().play)
        {
            change();
        }
        /*else
        {
            reset();
        }*/
    }

    private void change()
    {
        GameObject healthPrefab = GameObject.Find(nameForHealth);
        Health healthVariable = healthPrefab.GetComponent<Health>();
        healthVariable.myHealth += health;
    }

    private void reset()
    {
        GameObject healthPrefab = GameObject.Find(nameForHealth);
        Health healthVariable = healthPrefab.GetComponent<Health>();
        healthVariable.myHealth = orgHealth;
        checkedHealth = false;
    }
}
