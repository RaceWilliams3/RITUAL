using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid
{
    public int radius;
    public float cellSize;

    public List<HexCell> buildGrid(int radius, float cellSize)
    {
        int i = 0;
        int j = 0;
        int k = 0;

        List<HexCell> grid = new List<HexCell>();

        for (i = -radius; i < radius; i++)
        {
            for (j = -radius; j < radius; j++)
            {
                for (k = -radius; k < radius; k++)
                {
                    grid.Add(new HexCell(new Vector3(i, j, k)));
                }
            }
        }
        return grid;
    }

    public void printGrid(List<HexCell> grid)
    {
        for (int i = 0; i < grid.Count; i++)
        {
            Debug.Log(grid[i].getPos());
        }
    }

}


public class HexCell
{
    private Vector3 position;

    public HexCell(Vector3 position)
    {
        this.position = position;
    }

    public Vector3 getPos()
    {
        return position;
    }

}