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

    public void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            Debug.DrawRay(transform.position, cellDirections[i], Color.green);
        }
        //Debug.DrawRay(transform.position, cellDirections[0], Color.green);

    }

    public void checkForNeighbors()
    {
        RaycastHit hit;
        for (int i = 0; i < 6; i++)
        {
            if (Physics.Raycast(transform.position, cellDirections[i], out hit, 2))
            {
                neighbors[i] = hit.transform.gameObject;
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
        
    }

    public CellObject()
    {
        empty = true;
        //start with all empty cells as neighbors

        
    }
}

