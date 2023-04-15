using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIValuesPresenterScript : MonoBehaviour
{
    public TextMeshProUGUI NumberOfNotebooksText;
    public TextMeshProUGUI NumberOfCoinsText;

    void FixedUpdate()
    {
        NumberOfNotebooksText.text = EnvController.NumberOfPosessedNotebooks + "/" + EnvController.NumberOfNotebooks;
        NumberOfCoinsText.text = EnvController.NumberOfPosessedCoins.ToString();
    }
}
