using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Corruption : MonoBehaviour
{
    private float levelOfCorruption = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        InvokeRepeating("AddCorruption", 1, 1);
    }

    private void Update()
    {
        if (levelOfCorruption >= 300)
            SceneManager.LoadScene("Menu");
    }

    private void AddCorruption()
    {
        levelOfCorruption++;
    }
}
