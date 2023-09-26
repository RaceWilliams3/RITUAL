using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public bool[] currentTile = new bool[6];


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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotateTile();
        }
    }

  

    private void rotateTile()
    {
        Debug.Log("rotated");
        bool[] tempTile = new bool[6];
        tempTile = currentTile;

        for (int i = 1; i < 6; i++)
        {
            currentTile[i] = tempTile[i - 1];
            
        }
        currentTile[0] = tempTile[5];


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
