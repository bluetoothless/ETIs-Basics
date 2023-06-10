using EnvControllerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateOptionsScriptMenu : MonoBehaviour
{
    public Slider MouseSensitivitySlider;
    public Slider DifficultySlider;

    void Start()
    {
        MouseSensitivitySlider.value = EnvController.MouseSensitivity;
        PlayerPrefs.SetFloat("mouseSensitivity", 0f);
        PlayerPrefs.SetInt("difficulty", -1);
    }

    void Update()
    {
        PlayerPrefs.SetFloat("mouseSensitivity", (int)MouseSensitivitySlider.value);
        switch ((int)DifficultySlider.value)
        {
            case (int)Difficulty.Easy:
                PlayerPrefs.SetInt("difficulty", 0);
                break;
            case (int)Difficulty.Normal:
                PlayerPrefs.SetInt("difficulty", 1);
                break;
            case (int)Difficulty.Hard:
                PlayerPrefs.SetInt("difficulty", 2);
                break;
        }
    }

}
