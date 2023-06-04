using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintImage : MonoBehaviour
{

    public Image GreyImage;
    public Sprite ColorImage;

    public void ImageChange()
    {
        GreyImage.sprite = ColorImage;
    }
}
