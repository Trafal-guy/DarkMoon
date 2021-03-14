using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
   public void DestroyFloor()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter()
    {
        FindObjectOfType<AudioManager>().Play("WoodSound");
    }

    //private void OnTriggerExit()
    //{
    //    FindObjectOfType<AudioManager>().Stop("WoodSound");
    //}
}
