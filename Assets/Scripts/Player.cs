using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 initPosition;
    private float h, v;
    public int speed = 5; 

    private void Awake()
    {
        initPosition = new Vector3(-5.5f, 2.5f, 0);
        transform.position = initPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        h = 0;
        v = 0;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v= Input.GetAxisRaw("Vertical");
        if (canMove()) {
            transform.Translate(new Vector3(h*0.5f*speed*Time.deltaTime,v*0.5f* speed*Time.deltaTime, 0));
        }
    }
    private bool canMove() {
        return ((transform.position.x != -5.5f && h!=-1) || (transform.position.x != 5.5f && h != 1)) && ((transform.position.y != 2.5f && v != -1) || (transform.position.y != -2.5f && v != 1));
    }
}
