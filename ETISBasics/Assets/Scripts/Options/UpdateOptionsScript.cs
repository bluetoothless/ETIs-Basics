using EnvControllerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateOptionsScript : MonoBehaviour
{
    public Slider MouseSensitivitySlider;
    public Slider DifficultySlider;

    void Start()
    {
        MouseSensitivitySlider.value = EnvController.MouseSensitivity;
    }

    void Update()
    {
        EnvController.MouseSensitivity = (int)MouseSensitivitySlider.value;
        switch ((int)DifficultySlider.value)
        {
            case (int)Difficulty.Easy:
                SetDifficultyToEasy();
                break;
            case (int)Difficulty.Normal:
                SetDifficultyToNormal();
                break;
            case (int)Difficulty.Hard:
                SetDifficultyToHard();
                break;
        }
    }

    void SetDifficultyToEasy() 
    {
        EnvController.EnemySpeedUpStep = 20f;
        EnvController.EnemyChaseDistance = 500f;
        EnvController.InvulnerabilityTime = 20f;
    }

    void SetDifficultyToNormal()
    {
        EnvController.EnemySpeedUpStep = 72f;
        EnvController.EnemyChaseDistance = 1000f;
        EnvController.InvulnerabilityTime = 10f;
    }

    void SetDifficultyToHard()
    {
        EnvController.EnemySpeedUpStep = 120f;
        EnvController.EnemyChaseDistance = 2500f;
        EnvController.InvulnerabilityTime = 5f;
    }
}
