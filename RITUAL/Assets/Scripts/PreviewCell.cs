using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PreviewCell : MonoBehaviour
{
    /* Hex number system
     *        1
     *     6     2
     *     5     3
     *        4
     *                */

    public PreviewConnector[] connectors;
    public GameManager gameManager;

    public Material emptyMat;
    public Material filledMat;

    public int previewNumber;




    private Vector3[] cellDirections = {new Vector3(0f,0.2f,1f),
                                        new Vector3(1f,0.2f,0.5f),
                                        new Vector3(1f,0.2f,-0.5f),
                                        new Vector3(0f,0.2f,-1f),
                                        new Vector3(-1f,0.2f,-0.5f),
                                        new Vector3(-1f,0.2f,0.5f)};

    public bool empty = true;

    public void Start()
    {
        connectors = gameObject.GetComponentsInChildren<PreviewConnector>();
        foreach (PreviewConnector x in connectors)
        {
            x.gameObject.SetActive(false);
        }
        

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


    }



    private void Update()
    {
        
    }



    public void createConnectors(tile connectionMap)
    {
        for (int i = 0; i < 6; i++)
        {
            if (connectionMap.connectionStates[i] == true)
            {
                connectors[i].gameObject.SetActive(true);
            }
        }
    }

    public void hideConnectors()
    {
        if (empty)
        {
            for (int i = 0; i < 6; i++)
            {
                connectors[i].gameObject.SetActive(false);
            }
        }
    }

    public void UpdatePreview(Queue<tile> tileQueue)
    {
        hideConnectors();

        if (tileQueue.Count >= previewNumber)
        {
            createConnectors(tileQueue.ElementAt(previewNumber));
        }
        
    }

}

