using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    //private bool isWithPlayer = false;

    /*public void GetKey(KeyScript key)
    {
        key.isWithPlayer = true;
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            isWithPlayer = true;
            Destroy(gameObject);
        }
    }*/

    /*public bool inTrigger;

    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //DoorScript.doorKey = true;
                Destroy(this.gameObject);
            }
        }
    }

    void OnGUI()
    {
        if (inTrigger)
        {
            GUI.Box(new Rect(0, 60, 200, 25), "Press E to take key");
        }
    }*/

    public int index = -1;
    public void DestroyKey()
    {
        Destroy(gameObject);
    }
}