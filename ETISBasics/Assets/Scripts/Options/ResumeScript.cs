using EnvControllerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeScript : MonoBehaviour
{
    public void Resume()
    {
        var envControllerObj = GameObject.FindGameObjectWithTag("GameController");
        envControllerObj.gameObject.GetComponent<OptionsOpenerScript>().OpenOrCloseOptions();

    }
}
