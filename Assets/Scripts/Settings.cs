using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Settings : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] GameObject settingsPanel;
    public static int difficulty = 2;
    private Boolean isStart = true;

    void Start() {
        isStart = true;
        if (PlayerPrefs.HasKey("musicVolume") && PlayerPrefs.HasKey("difficulty")) {
            Load();
        } else {
            volumeSlider.value = 1;
            difficulty = 1;
            Save();
        }

        HideSettings();
        isStart = false;
    }

    public void ChangeVolume() {
        AudioListener.volume = volumeSlider.value; 
        Save();
    }

    public void ChangeDifficulty() {
        difficulty = dropdown.value + 1; 
        Save();
    }
    private void Load() {
        dropdown.value = PlayerPrefs.GetInt("difficulty");
        difficulty = dropdown.value + 1;
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        AudioListener.volume = volumeSlider.value;
    }

    private void Save() {
        if (isStart) {
            return;
        }

        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        PlayerPrefs.SetInt("difficulty", dropdown.value);
    }

    public void ShowSettings() {
        settingsPanel.SetActive(true);
    }

    public void HideSettings() {
        settingsPanel.SetActive(false);
    }
}
