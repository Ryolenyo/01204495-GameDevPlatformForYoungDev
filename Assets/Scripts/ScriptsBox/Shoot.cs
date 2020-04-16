using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject createdBullet;

    public float velocityX;
    public float velocityY;
    public float velocityZ;

    private bool shooted;

    // Start is called before the first frame update
    void Start()
    {
        shooted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<ScriptPlay>().play)
        {
            if (!shooted)
            {
                GameObject thisObject = gameObject.GetComponent<ScriptPlay>().thisObject;
                createdBullet = Instantiate(bullet, thisObject.transform.position, thisObject.transform.rotation);
                /*if (velocityX >= 0 && velocityY >= 0)
                {
                    createdBullet.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
                }
                else if (velocityX <= 0 && velocityY >= 0)
                {
                    createdBullet.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y+Mathf.Sqrt()  , transform.rotation.z, transform.rotation.w);
                }
                else if(velocityX <= 0 && velocityY <= 0)
                {

                }
                else
                {

                }   */
                if (createdBullet)
                {
                    if (Mathf.Abs(createdBullet.transform.position.x) < 500 && Mathf.Abs(createdBullet.transform.position.y) < 500)
                    {
                        createdBullet.transform.position = new Vector3(createdBullet.transform.position.x + velocityX,
                            createdBullet.transform.position.y + velocityY,
                            createdBullet.transform.position.z + velocityZ);
                    }
                }
                shooted = true;

            }
        }
        else
        {
            shooted = false;
        }
    }
}
