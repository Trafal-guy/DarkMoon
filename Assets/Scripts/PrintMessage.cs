using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintMessage : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private float time;
    private bool onScreen = false;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    public void ShowText()
    {
        if (onScreen == false)
        {
            text.SetActive(true);
            StartCoroutine("TextTime");
        }
    }

    // Update is called once per frame
    IEnumerator TextTime()
    {
        yield return new WaitForSeconds(time);
        text.SetActive(false);
        onScreen = false;
    }

    public void TextOnScreen()
    {
        onScreen = true;
    }
}
