using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject volumeBtn;
    public static SettingsMenu instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuteAudio()
    {
        AudioSource a = Camera.main.gameObject.GetComponent<AudioSource>();
        if (a != null) {
            a.volume = a.volume == 0 ? 1 : 0;
            TextMeshProUGUI tmp = volumeBtn.gameObject.GetComponentInChildren<TextMeshProUGUI>();
            tmp.color = a.volume == 0 ? Color.red : Color.green;
        }
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
