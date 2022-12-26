using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;

public class GridManager : MonoBehaviour
{
    //ESTA CLASE SE VA A ENCARGAR DE 
    /*
    Recibir Inputs
    Chequear si un objeto se puede mover y lanzar los Eventos
    Cambiar los tiles
    Generar el mapa inicial de acuerdo al scriptable LVL
    El scriptable level index debe estar en el Game Manager y yo lo busco del gameManager para generar
    
    EL SCRIPTABLE OBJECT VA A TENER 
    */
    /*
     * OTROS SCRIPTS DEBEN
     * Player
     * - Moverse de acuerdo al evento

     */
    [SerializeField]
    Tilemap walls, floor, boxes, obstacles, objectives;
    [SerializeField]
    GameObject playerPrefab;
    private int currentBoxes; // Voy a ir descontando cada vez que pongo una caja en su lugar
    [SerializeField]
    UnityEvent playerMovedUp, playerMovedDown,PlayerMovedLeft,PlayerMovedRight;
    [SerializeField]
    UnityEvent levelCompleted;
    [SerializeField]
    GameObject player;
    private float horizontalMovement, verticalMovement;

    // Start is called before the first frame update
    void Start()
    {
        
        //walls.SetTile(new Vector3Int(0,0,0), TileBase.)
    }

    void Update()
    {
        if (Input.GetButtonDown("Horizontal")){
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            if (canMoveHorizontal())
            {
                if (horizontalMovement == 1) PlayerMovedRight.Invoke();
                else PlayerMovedLeft.Invoke(); 
            }
        }
        if (Input.GetButtonDown("Vertical"))
        {
            verticalMovement = Input.GetAxisRaw("Vertical");
            if (canMoveVertical())
            {
                if (verticalMovement == 1) playerMovedUp.Invoke();
                else playerMovedDown.Invoke();
                
            }
        }
    }
    public bool canMoveHorizontal() {

        Vector3Int playerGridPosition = walls.WorldToCell(player.transform.position);

        if (walls.HasTile(playerGridPosition + new Vector3Int((int)horizontalMovement,0,0)) || obstacles.HasTile(playerGridPosition + new Vector3Int((int)horizontalMovement, 0, 0))) {
            return false;
        }
         

        return true;
        
    }
    public bool canMoveVertical()
    {

        Vector3Int playerGridPosition = walls.WorldToCell(player.transform.position);

        if (walls.HasTile(playerGridPosition + new Vector3Int(0, (int)verticalMovement, 0)) || obstacles.HasTile(playerGridPosition + new Vector3Int(0, (int)verticalMovement, 0)))
        {
            return false;
        }
        return true;

    }
}
