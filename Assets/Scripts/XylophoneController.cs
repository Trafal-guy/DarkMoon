using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XylophoneController : MonoBehaviour
{
    public int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentIndex == 7)
        {
            print("Xylophone Complete");
        }
    }
}
