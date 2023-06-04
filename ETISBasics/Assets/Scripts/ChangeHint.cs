using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using EnvControllerNamespace;

public class ChangeHint : MonoBehaviour
{

    public GameObject NotebookQuestionPanel;
    public Button Podpowiedz;
    public Sprite GreyImage;
    public Sprite ColorImage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EnvController.NumberOfPosessedCoins >= 2)
            Podpowiedz.GetComponent<Image>().sprite = ColorImage;
        else
            Podpowiedz.GetComponent<Image>().sprite = GreyImage;
    }
}
