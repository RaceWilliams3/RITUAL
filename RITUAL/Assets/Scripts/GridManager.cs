using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public HexGrid gridBuilder = new HexGrid();
    List<HexCell> cells = new List<HexCell>();

    public GameObject ball;


    void Start()
    {
        cells = gridBuilder.buildGrid(5, 1f);
        spawnGrid();
    }

    public void spawnGrid()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            Instantiate(ball, cells[i].getPos(),  Quaternion.identity);
        }
    }


    void Update()
    {
        
    }
}
