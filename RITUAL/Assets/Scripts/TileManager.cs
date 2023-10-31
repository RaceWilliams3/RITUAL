using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public tile currentTile = new tile(new bool[6]);

    public Queue<tile> tileQueue = new Queue<tile>();

    private CellObject[] cells;

    public PreviewCell[] previewCells;

    public CellObject selectedTile = null;


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
        previewCells = FindObjectsOfType<PreviewCell>();

        fillQueue();
        fillQueue();
        fillQueue();
        fillQueue();
        fillQueue();
        createNewTile();
        cells = FindObjectsOfType<CellObject>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentTile = rotateTile();
            if (selectedTile.empty && !selectedTile.isHome && selectedTile != null)
            {
                selectedTile.rotatePreview();
            }
        }
    }

  

    private tile rotateTile()
    {
        Debug.Log("rotated");
        tile tempTile = new tile(new bool[6]);
        tile tempTile2 = new tile(new bool[6]);
        tempTile = currentTile;

        tempTile2.connectionStates[0] = tempTile.connectionStates[1];
        tempTile2.connectionStates[1] = tempTile.connectionStates[2];
        tempTile2.connectionStates[2] = tempTile.connectionStates[3];
        tempTile2.connectionStates[3] = tempTile.connectionStates[4];
        tempTile2.connectionStates[4] = tempTile.connectionStates[5];
        tempTile2.connectionStates[5] = tempTile.connectionStates[0];

        return tempTile2;


    }


    private void printTest(bool[] tile)
    {
        Debug.Log(tile[0] +" "+ tile[1] + " " + tile[2] + " " + tile[3] + " " + tile[4] + " " + tile[5]);
    }




    public void createNewTile()
    {
        bool[] newTile = new bool[6];

        for (int i = 0; i < 6; i++)
        {
            if ((int)Random.Range(0, 100) % 2 == 0)
            {
                newTile[i] = true;
            } else
            {
                newTile[i] = false;
            }
        }

        currentTile = tileQueue.Dequeue();

        tileQueue.Enqueue(new tile(newTile));
        
        foreach (PreviewCell x in previewCells)
        {
            x.UpdatePreview(tileQueue);
        }

    }

    private void fillQueue()
    {
        bool[] newTile = new bool[6];

        for (int i = 0; i < 6; i++)
        {
            if ((int)Random.Range(0, 100) % 2 == 0)
            {
                newTile[i] = true;
            }
            else
            {
                newTile[i] = false;
            }
        }

        tileQueue.Enqueue(new tile(newTile));
    }

}
