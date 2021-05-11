using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool[] keys;
    public static bool[] soundPuzzleObjects;
    public static bool[] puzzleImages;

    private void Start()
    {
        keys = new bool[6];
        soundPuzzleObjects = new bool[4];
        puzzleImages = new bool[4];
        //keys[0] = true;
    }
}
