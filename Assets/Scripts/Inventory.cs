using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool[] keys;

    private void Start()
    {
        keys = new bool[6];
        //keys[0] = true;
    }
}
