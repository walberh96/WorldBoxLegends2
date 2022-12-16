using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject PanelMainMenu, panelLevelMenu,mainCamera,volumeBtn;
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
    public void MuteAudio(){
        AudioSource a = mainCamera.gameObject.GetComponent<AudioSource>();
        TextMeshProUGUI tmp = volumeBtn.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        a.volume= a.volume==0 ? 1 : 0;
        tmp.color = a.volume == 0 ? Color.red : Color.green ;
    }
}
