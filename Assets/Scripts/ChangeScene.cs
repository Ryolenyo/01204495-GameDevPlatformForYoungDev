using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Change(string scenename)
    {
        if (scenename == "Exit")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(scenename);
        }
    }
}
