using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanelUI : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        GameManager.instance.pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void returnToMenu() {
        GameManager.instance.StartLevel(0);
    
    }
}
