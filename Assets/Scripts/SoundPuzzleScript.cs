using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPuzzleScript : MonoBehaviour
{
    public int index = -1;
    public GameObject icon;
    // Start is called before the first frame update
    void Start()
    {
        icon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void AddIndex()
    {
        index++;
    }

    public void ActivateIcon()
    {
        icon.SetActive(true);
    }
}
