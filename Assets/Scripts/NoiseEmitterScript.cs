using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseEmitterScript : MonoBehaviour
{
    public int index;
    public Renderer soundObject;
    // Start is called before the first frame update
    void Start()
    {
        soundObject.GetComponent<Renderer>();
        soundObject.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateObject()
    {
        soundObject.enabled = true;
    }
}
