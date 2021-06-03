using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XylophoneController : MonoBehaviour
{
    public int currentIndex = 0;
    public GameObject np1, np2, np3, np4;

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

    public void PuzzleComplete()
    {
        StartCoroutine(Complete());
    }

    IEnumerator Complete()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("Right");
        np1.SetActive(true);
        np2.SetActive(true);
        np3.SetActive(true);
        np4.SetActive(true);
    }

}
