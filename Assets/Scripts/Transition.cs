using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [SerializeField] private GameObject uiobject;
    // Start is called before the first frame update
    void Start()
    {
        LockCursor();
        uiobject.SetActive(false);
        StartCoroutine("Timer");
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            SceneManager.LoadScene("Gameplay");
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        uiobject.SetActive(true);
    }
}
