using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SectionButtonHandler : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject[] closedPanel;
    private bool selected = false;

    public void Selected()
    {
        Debug.Log(this.name);
        selected = true;
        if(currentPanel)
            currentPanel.SetActive(true);
        for(int i=0; i<closedPanel.Length; i++)
        {
            closedPanel[i].SetActive(false);
        }
    }
}