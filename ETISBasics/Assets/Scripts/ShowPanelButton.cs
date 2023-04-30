using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanelButton : MonoBehaviour
{

    public string PanelId;

    private PanelManager _panelManager;

    private void Start()
    {
        _panelManager = PanelManager.Instance;
    }

    public void ShowPanel()
    {
        _panelManager.ShowPanel(PanelId);
    }

}