using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Corruption : MonoBehaviour
{
    private float levelOfCorruption = 0;
    public GameObject flash;
    // Start is called before the first frame update
    private void Awake()
    {
        InvokeRepeating("AddCorruption", 1, 1);
    }

    private void Update()
    {
        if (levelOfCorruption >= 1200)
            SceneManager.LoadScene("Menu");
        if(levelOfCorruption == 300)
        {
            FindObjectOfType<AudioManager>().Play("CreepyWhispers");
        }
        if(levelOfCorruption == 180)
        {
            flash.SetActive(true);
            StartCoroutine(lightning());
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
