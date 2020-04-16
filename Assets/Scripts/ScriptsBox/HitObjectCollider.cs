using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObjectCollider : MonoBehaviour
{
    public string collided;

    // Start is called before the first frame update
    void Start()
    {
        collided = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        collided = other.gameObject.name;
    }
    

    private void OnTriggerStay(Collider other)
    {
        collided = other.gameObject.name;
    }
}
