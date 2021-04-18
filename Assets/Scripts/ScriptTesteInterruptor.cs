using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para cada interruptor
public class ScriptTesteInterruptor : MonoBehaviour
{
    public GameObject mainCamera;
    public int valor;
    public bool ativo;

    // Start is called before the first frame update
    void Start()
    {
        ativo = false;
        if (tag == "Interruptor1")
        {
            valor = 1;
        }
        else if (tag == "Interruptor2")
        {
            valor = 2;
        }
        else if(tag == "Interruptor3")
        {
            valor = 3;
        }
        else if(tag == "Interruptor4")
        {
            valor = 4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Triggered when you click on the object
    private void OnMouseDown()
    {
        print(valor);
        if (ativo == false)
        {
            mainCamera.GetComponent<ScriptTeste>().valorTotal += valor;
            ativo = true;
            print(mainCamera.GetComponent<ScriptTeste>().valorTotal);
        }
        else
        {
            mainCamera.GetComponent<ScriptTeste>().valorTotal -= valor;
            ativo = false;
            print(mainCamera.GetComponent<ScriptTeste>().valorTotal);
        }
    }
}
