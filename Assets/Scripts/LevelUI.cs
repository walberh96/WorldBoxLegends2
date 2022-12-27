using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    [SerializeField]
    GameObject movesTxt, TimeTxt;
    private int movesCount = 0;
    private int timeCount = 0;
    private bool playing;
    // Start is called before the first frame update
    void Start()
    {
        playing = true;
        movesTxt.gameObject.GetComponent<TextMeshProUGUI>().text = "Moves :" + movesCount;
        TimeTxt.gameObject.GetComponent<TextMeshProUGUI>().text = "Time :" + timeCount;
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void addMove() {
        movesCount++;
        movesTxt.gameObject.GetComponent<TextMeshProUGUI>().text = "Moves :" + movesCount;
    }

    public IEnumerator timer() {
        while (playing)
        {
                yield return new WaitForSeconds(1);
                timeCount++;
                TimeTxt.gameObject.GetComponent<TextMeshProUGUI>().text = "Time :" + timeCount;
        }
    }
    public void win() {
        playing = false;
        StopCoroutine(timer());
    }
}
