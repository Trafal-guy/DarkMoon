using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para comandar os interruptores
public class ScriptTeste : MonoBehaviour
{
    public int valorTotal;

    // Start is called before the first frame update
    void Start()
    {
        valorTotal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (valorTotal == 8)
        {
            print("deu");
        }
    }
}
