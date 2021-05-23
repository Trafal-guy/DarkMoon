using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTesteTeleporte : MonoBehaviour
{
    public GameObject character;
    public GameObject spawner;

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
        StartCoroutine(WrongDoorEvent());
    }

    IEnumerator WrongDoorEvent()
    {
        yield return new WaitForSeconds(2);
        character.transform.position = spawner.transform.position;
        yield return new WaitForSeconds(1);
    }
}
