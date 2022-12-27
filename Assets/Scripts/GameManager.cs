using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            pause();
            SettingsMenu.instance.gameObject.SetActive(!SettingsMenu.instance.isActiveAndEnabled);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void pause() {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }
}
