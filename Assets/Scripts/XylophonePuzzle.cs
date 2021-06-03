using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XylophonePuzzle : MonoBehaviour
{
    public GameObject sceneCamera;
    public GameObject currentXylo, newXylo, originalXylo;
    public string soundName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
       /* if (sceneCamera.GetComponent<XylophoneController>().currentIndex == 1 && name == "XyloA")
        {
            sceneCamera.GetComponent<XylophoneController>().currentIndex += 1;
        }
        if (sceneCamera.GetComponent<XylophoneController>().currentIndex == 2 && name == "XyloE")
        {
            sceneCamera.GetComponent<XylophoneController>().currentIndex += 1;
        }
        if (sceneCamera.GetComponent<XylophoneController>().currentIndex == 3 && name == "XyloC")
        {
            sceneCamera.GetComponent<XylophoneController>().currentIndex += 1;
        }
        if (sceneCamera.GetComponent<XylophoneController>().currentIndex == 4 && name == "XyloD")
        {
            sceneCamera.GetComponent<XylophoneController>().currentIndex += 1;
        }
        if (sceneCamera.GetComponent<XylophoneController>().currentIndex == 5 && name == "XyloB")
        {
            sceneCamera.GetComponent<XylophoneController>().currentIndex += 1;
        }
        if (sceneCamera.GetComponent<XylophoneController>().currentIndex == 6 && name == "XyloA")
        {
            sceneCamera.GetComponent<XylophoneController>().currentIndex += 1;
        }
        else
        {
            sceneCamera.GetComponent<XylophoneController>().currentIndex = 1;
        }
       */

        if(tag == "RightNote")
        {
            sceneCamera.GetComponent<XylophoneController>().currentIndex += 1;
            FindObjectOfType<AudioManager>().Play(soundName);
            newXylo.SetActive(true);
            currentXylo.SetActive(false);
        }

        if(tag == "RightNote" && sceneCamera.GetComponent<XylophoneController>().currentIndex == 6)
        {
            sceneCamera.GetComponent<XylophoneController>().PuzzleComplete();
        }

        if(tag == "WrongNote" && sceneCamera.GetComponent<XylophoneController>().currentIndex != 1)
        {
            sceneCamera.GetComponent<XylophoneController>().currentIndex = 1;
            FindObjectOfType<AudioManager>().Play(soundName);
            originalXylo.SetActive(true);
            currentXylo.SetActive(false);
        }

    }

}
