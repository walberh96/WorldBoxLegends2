using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void StartGame(){
        PanelMainMenu.SetActive(false);
        panelLevelMenu.SetActive(true);
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void BackToMenuFromLevelSelection(){
        PanelMainMenu.SetActive(true);
        panelLevelMenu.SetActive(false);
    }
    public void StartLevel(int index){
        SceneManager.LoadScene(index);
    }
}
