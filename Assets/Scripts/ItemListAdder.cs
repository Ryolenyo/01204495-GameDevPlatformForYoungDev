using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemListAdder : MonoBehaviour
{
    public string itemName;
    public GameObject newItem;
    public GameObject itemPrefab;
    public List<string> itemList;
    public List<GameObject> itemGOList;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        itemName = "";
        itemList = new List<string>();
        itemGOList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (itemName != "")
        {
            AddText();
        }
    }

    void AddText()
    {
        count = 1;
        string temp = itemName;
        while(itemList.Contains(temp))
        {
            temp = itemName + "(" + count.ToString() + ")";
            count++;
        }
        newItem.name = temp;
        itemList.Add(newItem.name);
        itemGOList.Add(newItem);
        Debug.Log(newItem.name);

        GameObject item = Instantiate(itemPrefab) as GameObject;
        item.transform.SetParent(transform, false);
        item.name = newItem.name;
        item.GetComponentInChildren<Text>().text = "  "+newItem.name;
        itemName = "";
    }
}
