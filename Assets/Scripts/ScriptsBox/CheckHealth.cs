using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHealth : MonoBehaviour
{
    public bool isCheck;
    public string nameForHealth;
    public string sign;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<ScriptPlay>().play)
        {
            GameObject healthPrefab = GameObject.Find(nameForHealth);
            Health healthVariable = healthPrefab.GetComponent<Health>();
            if (sign == ">")
            {
                gameObject.GetComponent<ScriptPlay>().outVal = (healthVariable.myHealth > health);
            }
            else if (sign == "<")
            {
                gameObject.GetComponent<ScriptPlay>().outVal = (healthVariable.myHealth < health);
            }
            else if (sign == ">=")
            {
                gameObject.GetComponent<ScriptPlay>().outVal = (healthVariable.myHealth >= health);
            }
            else if (sign == "<=")
            {
                gameObject.GetComponent<ScriptPlay>().outVal = (healthVariable.myHealth <= health);
            }
            else if (sign == "=")
            {
                gameObject.GetComponent<ScriptPlay>().outVal = (healthVariable.myHealth == health);
            }
            else if (sign == "!=")
            {
                gameObject.GetComponent<ScriptPlay>().outVal = (healthVariable.myHealth != health);
            }
            else
            {
                gameObject.GetComponent<ScriptPlay>().outVal = false;
            }
        }
    }
}
