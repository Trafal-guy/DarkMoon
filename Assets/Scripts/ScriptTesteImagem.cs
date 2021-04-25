using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para cada interruptor para ativar a imagem
public class ScriptTesteImagem : MonoBehaviour
{
    public GameObject mainCamera;
    public int valor;
    public bool ativo;

    // Start is called before the first frame update
    void Start()
    {
        ativo = false;
        if (name == "imgInterruptor 1")
        {
            valor = mainCamera.GetComponent<ScriptTesteImagemController>().elements[0];
        }
        else if (name == "imgInterruptor 2")
        {
            valor = mainCamera.GetComponent<ScriptTesteImagemController>().elements[1];
        }
        else if (name == "imgInterruptor 3")
        {
            valor = mainCamera.GetComponent<ScriptTesteImagemController>().elements[2];
        }
        else if (name == "imgInterruptor 4")
        {
            valor = mainCamera.GetComponent<ScriptTesteImagemController>().elements[3];
        }
        else if (name == "imgInterruptor 5")
        {
            valor = mainCamera.GetComponent<ScriptTesteImagemController>().elements[4];
        }
        else if (name == "imgInterruptor 6")
        {
            valor = mainCamera.GetComponent<ScriptTesteImagemController>().elements[5];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (ativo == false)
        {
            if (valor == 1)
            {
                mainCamera.GetComponent<ScriptTesteImagemController>().panel1.SetActive(true);
                mainCamera.GetComponent<ScriptTesteImagemController>().valorFinal -= 1;
            }
            else if (valor == 2)
            {
                mainCamera.GetComponent<ScriptTesteImagemController>().panel2.SetActive(true);
                mainCamera.GetComponent<ScriptTesteImagemController>().valorFinal += 1;
            }
            else if(valor == 3)
            {
                mainCamera.GetComponent<ScriptTesteImagemController>().panel3.SetActive(true);
                mainCamera.GetComponent<ScriptTesteImagemController>().valorFinal += 1;
            }
            else if(valor == 4)
            {
                mainCamera.GetComponent<ScriptTesteImagemController>().panel4.SetActive(true);
                mainCamera.GetComponent<ScriptTesteImagemController>().valorFinal -= 1;
            }
            else if(valor == 5)
            {
                mainCamera.GetComponent<ScriptTesteImagemController>().panel5.SetActive(true);
                mainCamera.GetComponent<ScriptTesteImagemController>().valorFinal += 1;
            }
            else if(valor == 6)
            {
                mainCamera.GetComponent<ScriptTesteImagemController>().panel6.SetActive(true);
                mainCamera.GetComponent<ScriptTesteImagemController>().valorFinal += 1;
            }
            ativo = true;
        }
        else
        {
            if (valor == 1)
            {
                mainCamera.GetComponent<ScriptTesteImagemController>().panel1.SetActive(false);
                mainCamera.GetComponent<ScriptTesteImagemController>().valorFinal += 1;
            }
            else if (valor == 2)
            {
                mainCamera.GetComponent<ScriptTesteImagemController>().panel2.SetActive(false);
                mainCamera.GetComponent<ScriptTesteImagemController>().valorFinal -= 1;
            }
            else if (valor == 3)
            {
                mainCamera.GetComponent<ScriptTesteImagemController>().panel3.SetActive(false);
                mainCamera.GetComponent<ScriptTesteImagemController>().valorFinal -= 1;
            }
            else if (valor == 4)
            {
                mainCamera.GetComponent<ScriptTesteImagemController>().panel4.SetActive(false);
                mainCamera.GetComponent<ScriptTesteImagemController>().valorFinal += 1;
            }
            else if (valor == 5)
            {
                mainCamera.GetComponent<ScriptTesteImagemController>().panel5.SetActive(false);
                mainCamera.GetComponent<ScriptTesteImagemController>().valorFinal -= 1;
            }
            else if (valor == 6)
            {
                mainCamera.GetComponent<ScriptTesteImagemController>().panel6.SetActive(false);
                mainCamera.GetComponent<ScriptTesteImagemController>().valorFinal -= 1;
            }
            ativo = false;
        }
        print(mainCamera.GetComponent<ScriptTesteImagemController>().valorFinal);
    }
}
