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
    UnityEvent playerMovedUp, playerMovedDown, PlayerMovedLeft, PlayerMovedRight;
    [SerializeField]
    UnityEvent levelCompleted;
    [SerializeField]
    GameObject player;
    private float horizontalMovement, verticalMovement;
    [SerializeField]
    private Tile boxTile,objectiveTile, obstacleTile, wallTile;

    // Start is called before the first frame update
    void Start()
    {

        currentBoxes = 3;
    }

    void Update()
    {
        if (Input.GetButtonDown("Horizontal")){
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            if (canMoveHorizontal(walls.WorldToCell(player.transform.position)))
            {
                if (horizontalMovement == 1) PlayerMovedRight.Invoke();
                else PlayerMovedLeft.Invoke(); 
            }
        }
        if (Input.GetButtonDown("Vertical"))
        {
            verticalMovement = Input.GetAxisRaw("Vertical");
            if (canMoveVertical(walls.WorldToCell(player.transform.position)))
            {
                if (verticalMovement == 1) playerMovedUp.Invoke();
                else playerMovedDown.Invoke();
                
            }
        }
    }
    public bool canMoveHorizontal(Vector3Int objectGridPosition) {

        if (walls.HasTile(objectGridPosition + new Vector3Int((int)horizontalMovement,0,0)) || obstacles.HasTile(objectGridPosition + new Vector3Int((int)horizontalMovement, 0, 0)) || (boxes.HasTile(objectGridPosition) && boxes.HasTile(objectGridPosition + new Vector3Int((int)horizontalMovement, 0, 0)))  ) {
            return false;
        }
        if (boxes.HasTile(objectGridPosition + new Vector3Int((int)horizontalMovement, 0, 0)))
        {
            Debug.Log("Hay una caja frente a el");
            if (canMoveHorizontal(objectGridPosition + new Vector3Int((int)horizontalMovement, 0, 0)))
            {
                Debug.Log("Esa caja se puede mover");
                boxes.SetTile(objectGridPosition + new Vector3Int((int)horizontalMovement, 0, 0), null);
                boxes.SetTile(objectGridPosition + new Vector3Int((int)horizontalMovement*2, 0, 0),boxTile );

                if (objectives.HasTile(objectGridPosition + new Vector3Int((int)horizontalMovement * 2, 0, 0)))
                {
                    Debug.Log("Caja en objetivo");
                    currentBoxes--;
                    objectives.SetColor(objectGridPosition + new Vector3Int((int)horizontalMovement * 2, 0, 0), Color.cyan);
                    if (currentBoxes == 0)
                    {

                        Debug.Log(" You won");
                    }

                }
                if (objectives.HasTile(objectGridPosition + new Vector3Int((int)horizontalMovement, 0, 0))) {
                    Debug.Log("Caja fuera de objetivo");
                    currentBoxes++;
                    objectives.SetColor(objectGridPosition + new Vector3Int((int)horizontalMovement, 0, 0), Color.white);
                }

            }
            else {
                Debug.Log("Esa caja no se puede mover");
                return false;
            }
        }
        return true;
        
    }
    public bool canMoveVertical(Vector3Int objectGridPosition)
    {
        if (walls.HasTile(objectGridPosition + new Vector3Int(0, (int)verticalMovement, 0)) || obstacles.HasTile(objectGridPosition + new Vector3Int(0, (int)verticalMovement, 0)) || (boxes.HasTile(objectGridPosition) && boxes.HasTile(objectGridPosition + new Vector3Int(0, (int)verticalMovement, 0))))
        {
            return false;
        }
        if (boxes.HasTile(objectGridPosition + new Vector3Int(0, (int)verticalMovement, 0)))
        {
            
            Debug.Log("Hay una caja frente a el");
            if (canMoveVertical(objectGridPosition + new Vector3Int(0, (int)verticalMovement, 0)))
            {
                Debug.Log("Esa caja se puede mover");
                boxes.SetTile(objectGridPosition + new Vector3Int(0, (int)verticalMovement, 0), null);
                boxes.SetTile(objectGridPosition + new Vector3Int(0, (int)verticalMovement * 2, 0), boxTile);
                if (objectives.HasTile(objectGridPosition + new Vector3Int(0, (int)verticalMovement * 2, 0))) {
                    Debug.Log("Caja en objetivo");
                    currentBoxes--;
                    objectives.SetColor(objectGridPosition + new Vector3Int(0, (int)verticalMovement * 2, 0), Color.cyan);
                    if (currentBoxes == 0) {

                        Debug.Log(" You won");
                    }

                }
                if (objectives.HasTile(objectGridPosition + new Vector3Int(0, (int)verticalMovement, 0)))
                {
                    Debug.Log("Caja fuera de objetivo");
                    objectives.SetColor(objectGridPosition + new Vector3Int(0, (int)verticalMovement, 0), Color.white);
                    currentBoxes++;
                }

            }
            else
            {
                Debug.Log("Esa caja no se puede mover");
                return false;
            }
        }
        return true;
    }
}
