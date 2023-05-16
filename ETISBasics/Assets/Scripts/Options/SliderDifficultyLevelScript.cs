using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using EnvControllerNamespace;

public class SliderDifficultyLevelScript : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderValue;

    void Start()
    {
        slider.onValueChanged.AddListener((v) => {
            switch ((int)v)
            {
                case (int)Difficulty.Easy:
                    sliderValue.text = "EASY";
                    break;
                case (int)Difficulty.Normal:
                    sliderValue.text = "NORMAL";
                    break;
                case (int)Difficulty.Hard:
                    sliderValue.text = "HARD";
                    break;
            }
        });
    }
}
