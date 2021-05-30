using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoor : MonoBehaviour
{
    public GameObject currentGroup, newGroup, currentPainting, newPainting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGroup()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        currentPainting.SetActive(false);
        newPainting.SetActive(true);
        yield return new WaitForSeconds(3);
        newGroup.SetActive(true);
        currentGroup.SetActive(false);
    }
}
