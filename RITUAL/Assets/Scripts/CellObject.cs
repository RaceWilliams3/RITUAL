using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellObject : MonoBehaviour
{
    /* Hex number system
     *        1
     *     6     2
     *     5     3
     *        4
     *                */

    public GameObject[] neighbors = new GameObject[6];
    public Connector[] connectors;

    public Material emptyMat;
    public Material filledMat;


    

    private Vector3[] cellDirections = {new Vector3(0f,0.2f,1f),
                                        new Vector3(1f,0.2f,0.5f),
                                        new Vector3(1f,0.2f,-0.5f),
                                        new Vector3(0f,0.2f,-1f),
                                        new Vector3(-1f,0.2f,-0.5f),
                                        new Vector3(-1f,0.2f,0.5f)};

    public bool empty = true;

    public void Start()
    {
        connectors = gameObject.GetComponentsInChildren<Connector>();
        checkForNeighbors();

        foreach (Connector x in connectors)
        {
            x.gameObject.SetActive(false);
        }

    }

    public void connectorCollided(Connector connector)
    {
        Debug.Log("empty stats: " + empty);
        if (connector != null && empty == false)
        {
            Debug.Log("Point");
        }
    }

    void OnMouseDown()
    {
        empty = false;
        GetComponent<MeshRenderer>().material = filledMat;
        updateNeighbors();
        createConnectors(TileManager.instance.currentTile);

        TileManager.instance.createNewTile();

    }

    void OnMouseEnter()
    {
        if (empty)
        {
            createConnectors(TileManager.instance.currentTile);
        }
    }

    void OnMouseExit()
    {
        if (empty)
        {
            for (int i = 0; i < 6; i++)
            {
                connectors[i].gameObject.SetActive(false);
            }
        }
        
    }


    private void createConnectors(bool[] connectionMap)
    {
        for(int i = 0; i < 6; i++)
        {
            if (connectionMap[i] == true)
            {
                connectors[i].gameObject.SetActive(true);
            }
        }
    }

    public void checkForNeighbors()
    {
        RaycastHit hit;
        for (int i = 0; i < 6; i++)
        {
            if (Physics.Raycast(transform.position + new Vector3(0,-0.2f,0), cellDirections[i], out hit, 2))
            {
                Debug.DrawRay(transform.position + new Vector3(0, -0.2f, 0), cellDirections[i], Color.green);
                neighbors[i] = hit.transform.gameObject;
                //Debug.Log("Neighbor ray hit");
            } 
            else
            {
                Debug.DrawRay(transform.position + new Vector3(0, -0.2f, 0), cellDirections[i], Color.red);
            }
        }
    }



    public void updateNeighbors()
    {
        foreach (GameObject x in neighbors)
        {
            if (x != null)
            {
                
            }
            
        }

    }
}

