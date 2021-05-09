using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuScript : MonoBehaviour
{
    public GameObject menuPanel, menuUI, settingsUI;
    public AudioMixer audioMixer;

    //Main Menu
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(true);
            Time.timeScale = 0f;
            UnlockCursor();
        }
    }
    public void Resume()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
        LockCursor();
    }

    public void Settings()
    {
        menuUI.SetActive(false);
        settingsUI.SetActive(true);
    }
  
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //Settings Menu

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }

    public void ReturnMenu()
    {
        settingsUI.SetActive(false);
        menuUI.SetActive(true);
    }

    //Cursor
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //testes
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

}
