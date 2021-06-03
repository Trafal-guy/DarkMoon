using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para comandar os interruptores
public class ScriptTesteImagemController : MonoBehaviour
{
    public int[] elements = new int[6];
    public List<int> variables = new List<int>();
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public int valorFinal;
    public BoxCollider i1, i2, i3, i4, i5, i6;

    // Start is called before the first frame update
    void Awake()
    {
        valorFinal = 0;
        variables.Add(1); variables.Add(2); variables.Add(3); variables.Add(4); variables.Add(5); variables.Add(6);
        for (int i = 0; i < elements.Length; i++)
        {
            int s = variables[Random.Range(0, variables.Count)];
            elements[i] = s;
            variables.Remove(s);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (valorFinal == 4)
        {
            print("imagem correta");
            valorFinal += 1;
            FindObjectOfType<AudioManager>().Play("Right");
            i1.enabled = false;
            i2.enabled = false;
            i3.enabled = false;
            i4.enabled = false;
            i5.enabled = false;
            i6.enabled = false;
        }
    }
}
