using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject PanelMainMenu, panelLevelMenu;
    // Start is called before the first frame update
    void Start()
    {
        PanelMainMenu.SetActive(true);
        panelLevelMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
