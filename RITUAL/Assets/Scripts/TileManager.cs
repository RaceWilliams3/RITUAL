using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public bool[] currentTile = new bool[6];
    private CellObject[] cells;


    public static TileManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        createNewTile();
        cells = FindObjectsOfType<CellObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentTile = rotateTile();

            foreach (CellObject x in cells)
            {
                if (x.empty && !x.isHome)
                {
                    x.hideConnectors();
                    x.createConnectors(currentTile);
                }
            }
        }
    }

  

    private bool[] rotateTile()
    {
        Debug.Log("rotated");
        bool[] tempTile = new bool[6];
        bool[] tempTile2 = new bool[6];
        tempTile = currentTile;

        /*Debug.Log("Temp Tile: ");
        printTest(tempTile);


        Debug.Log("Current Tile: ");
        printTest(tempTile2);   */

        /*for (int i = 0; i < 5; i++)
        {
            if (i == 5)
            {
                tempTile2[i] = tempTile[0];
                break;
            }

            tempTile2[i] = tempTile[i + 1];
        }*/
        tempTile2[0] = tempTile[1];
        tempTile2[1] = tempTile[2];
        tempTile2[2] = tempTile[3];
        tempTile2[3] = tempTile[4];
        tempTile2[4] = tempTile[5];
        tempTile2[5] = tempTile[0];




       /* Debug.Log("Temp Tile: ");
        printTest(tempTile);
        
        
        Debug.Log("Current Tile: ");
        printTest(tempTile2);*/

        return tempTile2;


    }


    private void printTest(bool[] tile)
    {
        Debug.Log(tile[0] +" "+ tile[1] + " " + tile[2] + " " + tile[3] + " " + tile[4] + " " + tile[5]);
    }




    public void createNewTile()
    {
        for (int i = 0; i < 6; i++)
        {
            if ((int)Random.Range(0, 100) % 2 == 0)
            {
                currentTile[i] = true;
            } else
            {
                currentTile[i] = false;
            }
        }
    }

}
