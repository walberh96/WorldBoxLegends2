using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MoveUp() {
        Debug.Log("MovedUp");
        transform.position = transform.position + new Vector3(0,1,0) ;

    }
    public void MoveDown()
    {
        Debug.Log("MovedDown");
        transform.position = transform.position + new Vector3(0, -1, 0);
    }
    public void MoveLeft()
    {
        Debug.Log("MovedLeft");
        transform.position = transform.position + new Vector3(-1, 0, 0);
    }
    public void MoveRight()
    {
        Debug.Log("MovedRight");
        transform.position = transform.position + new Vector3(1, 0, 0);
    }

}
