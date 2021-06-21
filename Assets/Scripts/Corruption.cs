using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Corruption : MonoBehaviour
{
    private float levelOfCorruption = 0;
    public GameObject flash, ghostObjects;
    public Renderer oldHouse, newHouse;
    // Start is called before the first frame update
    private void Awake()
    {
        InvokeRepeating("AddCorruption", 1, 1);
    }

    private void Update()
    {
        if (levelOfCorruption >= 1200)
            SceneManager.LoadScene("Menu");
        if(levelOfCorruption == 240)
        {
            FindObjectOfType<AudioManager>().Play("CreepyWhispers");
        }
        if(levelOfCorruption == 120)
        {
            flash.SetActive(true);
            StartCoroutine(lightning());
        }
        if(levelOfCorruption == 180)
        {
            newHouse.enabled = false;
            oldHouse.enabled = true;
        }
        if(levelOfCorruption == 300)
        {
            ghostObjects.SetActive(true);
        }
    }

    private void AddCorruption()
    {
        levelOfCorruption++;
    }
    IEnumerator lightning()
    {
        yield return new WaitForSeconds(.5f);
        flash.SetActive(false);
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("Thunder");

    }
}
