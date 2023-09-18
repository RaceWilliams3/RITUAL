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

    public Material emptyMat;
    public Material filledMat;

    private Vector3[] cellDirections = {new Vector3(0f,0.2f,1f),
                                        new Vector3(1f,0.2f,0.5f),
                                        new Vector3(1f,0.2f,-0.5f),
                                        new Vector3(0f,0.2f,-1f),
                                        new Vector3(-1f,0.2f,-0.5f),
                                        new Vector3(-1f,0.2f,0.5f)};

    public bool empty;

    public void Start()
    {
        checkForNeighbors();
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

    void OnMouseDown()
    {
        if (empty)
        {
            GetComponent<MeshRenderer>().material = filledMat;
        } else
        {
            GetComponent<MeshRenderer>().material = emptyMat;
        }
        empty = !empty;
        updateNeighbors();
        
    }

    public void updateNeighbors()
    {
        foreach (GameObject x in neighbors)
        {
            if (x != null)
            {
                if (x.GetComponent<CellObject>().empty)
                {
                    x.GetComponent<MeshRenderer>().material = filledMat;
                }
                else
                {
                    x.GetComponent<MeshRenderer>().material = emptyMat;
                }
                x.GetComponent<CellObject>().empty = !x.GetComponent<CellObject>().empty;
            }
            
        }

    }

    public CellObject()
    {
        empty = true;
        //start with all empty cells as neighbors

        
    }
}

