
using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject PanelMainMenu, panelLevelMenu;
    
    void Start()
    {
        PanelMainMenu.SetActive(true);
        panelLevelMenu.SetActive(false);
    }

    public void StartGame(){
        PanelMainMenu.SetActive(false);
        panelLevelMenu.SetActive(true);
    }



    public void BackToMenuFromLevelSelection(){
        PanelMainMenu.SetActive(true);
        panelLevelMenu.SetActive(false);
    }
}
