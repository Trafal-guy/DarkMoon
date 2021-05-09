using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Rendering.PostProcessing;
using System;

public class MenuScript : MonoBehaviour
{
    public GameObject menuPanel, menuUI, settingsUI;
    public AudioMixer audioMixer;
    public SliderSettings brightnessSlider;
    public PostProcessProfile profile;
    public float brightnessValue;

    //private ColorGrading colorGrading;

    public void Start()
    {
        brightnessSlider.slider.onValueChanged.AddListener(delegate { Brightness(brightnessSlider.slider.value); });
    }
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

    public void SetBrightness(float brightness)
    {
        Debug.Log(brightness);
        //colorGrading.postExposure.Override(brightness);
    }

    public void ReturnMenu()
    {
        settingsUI.SetActive(false);
        menuUI.SetActive(true);
    }

    void Brightness(float currentValue)
    {
        float finalValue;
        finalValue = ConvertValue(brightnessSlider.slider.minValue, brightnessSlider.slider.maxValue, brightnessSlider.minSettingValue, brightnessSlider.maxSettingValue, currentValue);
        profile.GetSetting<ColorGrading>().postExposure.Override(finalValue);
        brightnessValue = currentValue;
        //brightnessSlider.textSlider.text = Mathf.RoundToInt(currentValue).ToString();
    }

    private float ConvertValue(float minValue, float maxValue, float minSettingValue, float maxSettingValue, float currentValue)
    {
        float ratio = (maxSettingValue - minSettingValue) / (maxValue - minValue);
        float returnValue = ((currentValue * ratio) - (minValue * ratio)) + minSettingValue;
        return returnValue;
    }


    //Cursor
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

}
