using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueScript : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderValue;

    void Start()
    {
        slider.onValueChanged.AddListener((v) => {
            sliderValue.text = v.ToString("0");
        });
    }
}
