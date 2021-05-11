using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{ 
    public int index = -1;
    public void DestroyKey()
    {
        Destroy(gameObject);
    }
}